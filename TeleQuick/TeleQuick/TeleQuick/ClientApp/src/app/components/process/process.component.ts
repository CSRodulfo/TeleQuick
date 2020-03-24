import { Component, OnInit } from "@angular/core";
import { fadeInOut } from "../../services/animations";
import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import { AlertService, MessageSeverity } from "../../services/alert.service";
import { Utilities } from "../../services/utilities";
import { OAuthService } from "angular-oauth2-oidc";

import { Message } from "../../models/Message";
import { BusinessService } from "../../services/business.service";
import { GlobalResources } from "../../services/globalResources";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// RECOMMENDED

import { CollapseModule } from 'ngx-bootstrap/collapse';


@Component({
  selector: "process",
  templateUrl: "./process.component.html",
  styleUrls: ["./process.component.scss"],
  animations: [fadeInOut]
})
export class ProcessComponent implements OnInit {
  max: number = 200;
  showWarning: boolean;
  dynamic: number;
  type: any = "info";
  text: string = "Detalle del Procesamiento";
  textDescription : string = "";
  isCollapsed = false;
  
  constructor(
    private oauthService: OAuthService,
    private alertService: AlertService,
    private businessService: BusinessService,
    private resx: GlobalResources
  ) {}

  ngOnInit(): void {
    this.dynamic = 0;
  }

  random(): void {

    const connection = new HubConnectionBuilder()
    //.configureLogging(signalR.LogLevel.Information)
    .withUrl("https://localhost:44350/notify", {
      transport: 4,
      accessTokenFactory: () => this.oauthService.getAccessToken()
    })
    .configureLogging(LogLevel.Trace)
    .build();

    this.connect(connection);

    this.businessService.getProcess().subscribe({
      next: (results: any) => {
        this.onDataLoadSuccessful();
      },
      error: (error: any) => {
        this.onDataLoadFailed(error);
      },
      complete: () => {

        console.log("complete");
        connection.stop();
      }
    });
  }

  onDataLoadSuccessful() {
    this.alertService.stopLoadingMessage();
  }

  onDataLoadFailed(error: any) {
    this.alertService.stopLoadingMessage();

    this.alertService.showStickyMessage(
      this.resx.loadError,
      `${this.resx.loadErrorDetail} ${Utilities.getHttpResponseMessages(
        error
      )}"`,
      MessageSeverity.error,
      error
    );
  }

  connect(connection: any ): void {
    connection
      .start()
      .then(function() {
        console.log("Connected!");
      })
      .catch(function(err) {
        return console.error(err.toString());
      });

    connection.on("SendMessageUser", (description: string, value: string) => {
      this.dynamic = this.dynamic + 10;
      this.text = description;
      this.textDescription += description +"\n"
    });
  }
}

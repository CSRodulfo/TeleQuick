
import { Component, OnInit } from '@angular/core';
import { fadeInOut } from '../../services/animations';
import { ProgressbarModule } from 'ngx-bootstrap/progressbar';
import { HubConnectionBuilder } from '@aspnet/signalr';
import { AlertService, MessageSeverity } from '../../services/alert.service';
import { Utilities } from '../../services/utilities';

import { Message } from '../../models/Message';
import { BusinessService } from '../../services/business.service';
import { GlobalResources } from '../../services/globalResources'

@Component({
  selector: 'process',
  templateUrl: './process.component.html',
  styleUrls: ['./process.component.scss'],
  animations: [fadeInOut]
})
export class ProcessComponent implements OnInit {
  max: number = 200;
  showWarning: boolean;
  dynamic: number;
  type: any = 'info';
  text: string;

  constructor(private alertService: AlertService, private businessService: BusinessService, private resx: GlobalResources) {

  }

  ngOnInit(): void {
    this.dynamic = 0;

    this.connect();


  }


  random(): void {
    this.alertService.startLoadingMessage();
    this.dynamic = 0;

    this.businessService.getProcess().subscribe({
      next: (results: any) => { this.onDataLoadSuccessful() },
      error: (error: any) => { this.onDataLoadFailed(error) },
      complete: () => { console.log('complete') }
    });
  }

  onDataLoadSuccessful() {
    this.alertService.stopLoadingMessage();
  }

  onDataLoadFailed(error: any) {
    this.alertService.stopLoadingMessage();

    this.alertService.showStickyMessage(this.resx.loadError, `${this.resx.loadErrorDetail} ${Utilities.getHttpResponseMessages(error)}"`,
      MessageSeverity.error, error);

    this.connect();
  }

  connect(): void {
    const connection = new HubConnectionBuilder()
      //.configureLogging(signalR.LogLevel.Information)
      .withUrl("https://localhost:4200/notify")
      .build();

    connection.start().then(function () {
      console.log('Connected!');
    }).catch(function (err) {
      return console.error(err.toString());
    });

    connection.on("BroadcastMessage", (type: string, payload: string) => {
      this.dynamic = this.dynamic + 10;
      this.text = type;
    });
  }

}

// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

import { Component, OnInit } from '@angular/core';
import { fadeInOut } from '../../services/animations';
import { ProgressbarModule } from 'ngx-bootstrap/progressbar';
import { HubConnectionBuilder } from '@aspnet/signalr';
import { AlertService, MessageSeverity } from '../../services/alert.service';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

import { Message } from '../../models/Message';
import { ChatService } from '../../services/chat.service';

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
    type: string;
    text: string;

    name = 'Set iframe source';
    url: string = "https://binlbc.axshare.com/#id=o5m8pw&p=page_3&c=1";
    urlSafe: any; //SafeResourceUrl;

    constructor(private alertService: AlertService, public sanitizer: DomSanitizer) {
        this.urlSafe = this.sanitizer.bypassSecurityTrustResourceUrl(this.url);
    }

    ngOnInit(): void {
      this.random();
      this.dynamic = 0;

        const connection = new HubConnectionBuilder()
            //.configureLogging(signalR.LogLevel.Information)
            .withUrl("https://localhost:44350/notify")
            .build();

        connection.start().then(function () {
            console.log('Connected!');
        }).catch(function (err) {
            return console.error(err.toString());
        });

        connection.on("BroadcastMessage", (type: string, payload: string) => {
            this.dynamic = this.dynamic + 10 ;
            this.text = type;
            this.type = 'info';
           // this.alertService.showMessage(type, payload, MessageSeverity.error);
        });
    }


    random(): void {

    }
}

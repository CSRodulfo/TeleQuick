// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { fadeInOut } from '../../services/animations';
import { ProgressbarModule } from 'ngx-bootstrap/progressbar';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
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

    name = 'Set iframe source';
    url: string = "http://127.0.0.1:32767/start.html#id=o5m8pw&p=page_3&c=1";
    urlSafe: any; //SafeResourceUrl;

    constructor(private alertService: AlertService, public sanitizer: DomSanitizer) {

    }

    ngOnInit(): void {
        this.urlSafe = this.sanitizer.bypassSecurityTrustResourceUrl(this.url);

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
            this.random();
            this.alertService.showMessage(type, payload, MessageSeverity.error);
        });
    }


    random(): void {
        let value = Math.floor(Math.random() * 100 + 1);
        let type: string;

        if (value < 25) {
            type = 'success';
        } else if (value < 50) {
            type = 'info';
        } else if (value < 75) {
            type = 'warning';
        } else {
            type = 'danger';
        }

        this.dynamic = value;
        this.type = type;
    }
}
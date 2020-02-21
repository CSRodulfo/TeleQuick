// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

import { Component, NgZone } from '@angular/core';
import { fadeInOut } from '../../services/animations';
import { ProgressbarModule } from 'ngx-bootstrap/progressbar';

import { Message } from '../../models/Message';
import { ChatService } from '../../services/chat.service';

@Component({
    selector: 'process',
    templateUrl: './process.component.html',
    styleUrls: ['./process.component.scss'],
    animations: [fadeInOut]
})
export class ProcessComponent {
    max: number = 200;
    showWarning: boolean;
    dynamic: number;
    type: string;

    title = 'ClientApp';
    txtMessage: string = '';
    uniqueID: string = new Date().getTime().toString();
    messages = new Array<Message>();
    message = new Message();

    constructor(private chatService: ChatService, private zone: NgZone) {
        this.subscribeToEvents();
        this.random();
    }
    sendMessage(): void {
        if (this.txtMessage) {
            this.message = new Message();
            this.message.clientuniqueid = this.uniqueID;
            this.message.type = "sent";
            this.message.message = this.txtMessage;
            this.message.date = new Date();
            this.messages.push(this.message);
            this.chatService.sendMessage(this.message);
            this.txtMessage = '';
        }
    }
    private subscribeToEvents(): void {

        this.chatService.messageReceived.subscribe((message: Message) => {
            this.zone.run(() => {
                if (message.clientuniqueid !== this.uniqueID) {
                    message.type = "received";
                    this.messages.push(message);
                }
            });
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
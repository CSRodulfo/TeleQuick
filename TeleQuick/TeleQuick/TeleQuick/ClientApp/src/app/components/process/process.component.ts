// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

import { Component } from '@angular/core';
import { fadeInOut } from '../../services/animations';
import { ProgressbarModule } from 'ngx-bootstrap/progressbar';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

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

    name = 'Set iframe source';
    url: string = "http://127.0.0.1:32767/start.html#id=o5m8pw&p=page_3&c=1";
    urlSafe: any; //SafeResourceUrl;

    constructor(public sanitizer: DomSanitizer) {
        this.urlSafe= this.sanitizer.bypassSecurityTrustResourceUrl(this.url);
        this.random();
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
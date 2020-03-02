import { Component, OnInit } from '@angular/core';
import { fadeInOut } from '../../services/animations';
import { HubConnectionBuilder } from '@aspnet/signalr';
import { AlertService, MessageSeverity } from '../../services/alert.service';


@Component({
  selector: 'registrations',
  templateUrl: './registrations.component.html',
  styleUrls: ['./registrations.component.css'],
  animations: [fadeInOut]
})
export class RegistrationsComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}

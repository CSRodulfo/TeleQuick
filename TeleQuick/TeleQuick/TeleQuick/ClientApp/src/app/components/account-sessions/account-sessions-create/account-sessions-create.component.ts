import { Component, OnInit, ViewChild, Input } from '@angular/core';

import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { Utilities } from '../../../services/utilities';
import { AccountSession } from '../../../models/accountSession.model';
import { NgForm } from '@angular/forms';
import { BusinessService } from '../../../services/business.service';

@Component({
  selector: 'app-account-sessions-create',
  templateUrl: './account-sessions-create.component.html',
  styleUrls: ['./account-sessions-create.component.scss']
})
export class AccountSessionsCreateComponent implements OnInit {

  public entityAccountSession = new AccountSession();

  public changesSavedCallback: () => void;
  public changesFailedCallback: () => void;
  public changesCancelledCallback: () => void;

  @ViewChild('f', { static: false })
  private form: NgForm

  constructor(private alertService: AlertService, private businessService: BusinessService) {
  }

  ngOnInit() {

  }

  onSubmit() {

    if (this.form.valid) {
      this.save();
    } else {
      this.alertService.showMessage('Error de validación', 'Por favor complete todos los campos',MessageSeverity.error);
    }
  }

  save() {
    this.alertService.startLoadingMessage('Grabando cambios ...');
   // this.businessService.postVehicle(this.entityVehicle).subscribe(role => this.saveSuccessHelper(), error => this.saveFailedHelper(error));
  }

  private saveSuccessHelper() {
    this.alertService.stopLoadingMessage();
    this.alertService.showMessage('Creado', `El Vehiculo fue creado exitosamente`, MessageSeverity.success);

    this.form.resetForm();
    
    if (this.changesSavedCallback) {
      this.changesSavedCallback();
    }
  }

  private saveFailedHelper(error: any) {
    this.alertService.stopLoadingMessage();
    this.alertService.showStickyMessage('Error al crear:', `Ha Acurrido un \r\nError: "${Utilities.getHttpResponseMessages(error)}"`, MessageSeverity.error, error);

    if (this.changesFailedCallback) {
      this.changesFailedCallback();
    }
  }

  closeModel() {
    this.form.resetForm();
    if (this.changesCancelledCallback) {
      this.changesCancelledCallback();
    }
  }
}
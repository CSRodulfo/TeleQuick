import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { NgForm } from '@angular/forms';

import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { Utilities } from '../../../services/utilities';
import { AccountSession } from '../../../models/account-session.model';
import { BusinessService } from '../../../services/business.service';

@Component({
  selector: 'account-sessions-edit',
  templateUrl: './account-sessions-edit.component.html',
  styleUrls: ['./account-sessions-edit.component.scss']
})
export class AccountSessionsEditComponent implements OnInit {

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
      this.Update();
    } else {
      this.alertService.showMessage('Error de validación', 'Por favor complete todos los campos', MessageSeverity.error);
    }
  }

  Update() {
    this.alertService.startLoadingMessage('Guardando cambios ...');
    this.businessService.putAccountSession(this.entityAccountSession).subscribe(role => this.saveSuccessHelper(), error => this.saveFailedHelper(error));
  }

  private saveSuccessHelper() {
    this.alertService.stopLoadingMessage();
    this.alertService.showMessage('Actualizar', `La cuenta de usuario fue actualizado exitosamente`, MessageSeverity.success);

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
    if (this.changesCancelledCallback) {
      this.changesCancelledCallback();
    }
  }
}
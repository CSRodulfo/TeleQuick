import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { NgForm } from '@angular/forms';

import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { Utilities } from '../../../services/utilities';
import { AccountSession } from '../../../models/account-session.model';
import { BusinessService } from '../../../services/business.service';
import { GlobalResources } from '../../../services/globalResources'


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

  @ViewChild('f')
  private form: NgForm

  constructor(private alertService: AlertService, private businessService: BusinessService,
    private resx: GlobalResources) {
  }

  ngOnInit() {
  }

  onSubmit() {
    if (this.form.valid) {
      this.Update();
    } else {
      this.alertService.showMessage(this.resx.saveValidationError, this.resx.saveValidationErrorDetail, MessageSeverity.error);
    }
  }

  Update() {
    this.alertService.startLoadingMessage(this.resx.saveSaving);
    this.businessService.putAccountSession(this.entityAccountSession).subscribe({
      next: (role: any) => { this.saveSuccessHelper() },
      error: (error: any) => { this.saveFailedHelper(error) },
      complete: () => { console.log('complete') }
    });
  }

  private saveSuccessHelper() {
    this.alertService.stopLoadingMessage();
    this.alertService.showMessage(this.resx.updateSucces, this.resx.updateSuccesDetail, MessageSeverity.success);

    this.form.resetForm();

    if (this.changesSavedCallback) {
      this.changesSavedCallback();
    }
  }

  private saveFailedHelper(error: any) {
    this.alertService.stopLoadingMessage();
    this.alertService.showStickyMessage(this.resx.updateError, `${this.resx.updateErrorDetail} ${Utilities.getHttpResponseMessages(error)}`, MessageSeverity.error, error);

    if (this.changesFailedCallback) {
      this.changesFailedCallback();
    }
  }

  closeModel() {
    if (this.changesCancelledCallback) {
      this.changesCancelledCallback();
    }
  }

  testConeccionAU() {
    this.alertService.startLoadingMessage('Probando conexión');
    this.businessService.getAccountSessionValidateConection(this.entityAccountSession)
      .subscribe(
        results => {
          this.alertService.stopLoadingMessage();
          if (results) {
            this.entityAccountSession.isValid = true;
            this.alertService.showMessage('Conexión Valida', 'La prueba de conectividad fue realizada exitosamente', MessageSeverity.success);
          } else {
            this.entityAccountSession.isValid = false;
            this.alertService.showMessage('Conexión Invalida', 'Prueba de conectividad no es valida', MessageSeverity.error);
          }
        },
        error => {
          this.alertService.stopLoadingMessage();
          this.entityAccountSession.isValid = false;
          this.alertService.showStickyMessage('Error al conectar', `'Se produjo un error al validar la conección: ' ${Utilities.getHttpResponseMessages(error)}"`,
            MessageSeverity.error, error);
        });
  }
}

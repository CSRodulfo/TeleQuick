import { Component, OnInit, ViewChild, Input } from '@angular/core';

import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { Utilities } from '../../../services/utilities';
import { AccountSession } from '../../../models/account-session.model';
import { NgForm } from '@angular/forms';
import { BusinessService } from '../../../services/business.service';
import { GlobalResources } from '../../../services/globalResources'

@Component({
  selector: 'account-sessions-create',
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

  constructor(private alertService: AlertService, private businessService: BusinessService,
    private resx: GlobalResources) {
  }

  ngOnInit() {

  }

  onSubmit() {
    if (this.form.valid) {
      this.save();
    } else {
      this.alertService.showMessage(this.resx.saveValidationError, this.resx.saveValidationErrorDetail, MessageSeverity.error);
    }
  }

  save() {
    this.alertService.startLoadingMessage(this.resx.saveSaving);
    this.businessService.postAccountSession(this.entityAccountSession).subscribe(role => this.saveSuccessHelper(), error => this.saveFailedHelper(error));
  }

  private saveSuccessHelper() {
    this.alertService.stopLoadingMessage();
    this.alertService.showMessage(this.resx.saveSucces, this.resx.saveSuccesDetail, MessageSeverity.success);

    this.form.resetForm();

    if (this.changesSavedCallback) {
      this.changesSavedCallback();
    }
  }

  private saveFailedHelper(error: any) {
    this.alertService.stopLoadingMessage();
    this.alertService.showStickyMessage(this.resx.saveError, `${this.resx.saveErrorDetail} ${Utilities.getHttpResponseMessages(error)}`, MessageSeverity.error, error);

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
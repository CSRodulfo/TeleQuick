// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

import { Component, OnInit, ViewChild, Input } from '@angular/core';

import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { Utilities } from '../../../services/utilities';
import { Vehicle } from '../../../models/vehicle.model';
import { NgForm } from '@angular/forms';
import { BusinessService } from '../../../services/business.service';
import { GlobalResources } from '../../../services/globalResources'

@Component({
  selector: 'vehicle-edit',
  templateUrl: './vehicle-edit.component.html',
  styleUrls: ['./vehicle-edit.component.scss']
})

export class VehicleEditComponent implements OnInit {

  public entityVehicle = new Vehicle();

  public changesSavedCallback: () => void;
  public changesFailedCallback: () => void;
  public changesCancelledCallback: () => void;

  @ViewChild('f', { static: false })
  private form: NgForm

  constructor(private alertService: AlertService, private businessService: BusinessService,
    private resx: GlobalResources)  {
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
    this.businessService.putVehicle(this.entityVehicle).subscribe(role => this.saveSuccessHelper(), error => this.saveFailedHelper(error));
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
}
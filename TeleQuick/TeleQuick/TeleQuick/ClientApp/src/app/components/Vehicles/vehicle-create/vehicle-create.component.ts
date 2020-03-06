
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { Utilities } from '../../../services/utilities';
import { Vehicle } from '../../../models/vehicle.model';
import { NgForm } from '@angular/forms';
import { BusinessService } from '../../../services/business.service';
import { GlobalResources } from '../../../services/globalResources'

@Component({
  selector: 'vehicle-create',
  templateUrl: './vehicle-create.component.html',
  styleUrls: ['./vehicle-create.component.scss']
})

export class VehicleCreateComponent implements OnInit {

  public entityVehicle = new Vehicle();

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
    this.businessService.postVehicle(this.entityVehicle).subscribe({
      next: (results: any) => { this.saveSuccessHelper() },
      error: (error: any) => { this.saveFailedHelper(error) },
      complete: () => { console.log('complete') }
    });
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

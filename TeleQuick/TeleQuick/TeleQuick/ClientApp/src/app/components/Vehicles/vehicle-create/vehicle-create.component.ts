// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

import { Component, OnInit, ViewChild, Input } from '@angular/core';

import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { AccountService } from '../../../services/account.service';
import { Utilities } from '../../../services/utilities';
import { Vehicle } from '../../../models/vehicle.model';
import { NgForm } from '@angular/forms';
import { BusinessService } from '../../../services/business.service';

@Component({
  selector: 'vehicle-create',
  templateUrl: './vehicle-create.component.html',
  styleUrls: ['./vehicle-create.component.scss']
})

export class VehicleCreateComponent implements OnInit {

  public isEditMode = false;
  public isNewUser = false;
  public entityVehicle = new Vehicle();

  public changesSavedCallback: () => void;
  public changesFailedCallback: () => void;
  public changesCancelledCallback: () => void;
  public closeCallback: () => void;

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
      this.showErrorAlert('Error de validación', 'Por favor complete todos los campos');
    }
    console.log(this.form.value);  // { first: '', last: '' }
    console.log(this.form.valid);  // false

    this.entityVehicle;
  }

  showErrorAlert(caption: string, message: string) {
    this.alertService.showMessage(caption, message, MessageSeverity.error);
  }


  save() {
    this.alertService.startLoadingMessage('Grabando cambios ...');
    this.businessService.postVehicle(this.entityVehicle).subscribe(role => this.saveSuccessHelper(), error => this.saveFailedHelper(error));
  }

  private saveSuccessHelper() {
    this.alertService.stopLoadingMessage();
    this.alertService.showMessage('Creado', `El Vehiculo fue creado exitosamente`, MessageSeverity.success);
    this.form.reset();
    
    this.closeCallback();
  }

  private saveFailedHelper(error: any) {
    this.alertService.stopLoadingMessage();
    this.alertService.showStickyMessage('Error al crear:', `Ha Acurrido un \r\nError: "${Utilities.getHttpResponseMessages(error)}"`, MessageSeverity.error, error);

    if (this.changesFailedCallback) {
      this.changesFailedCallback();
    }
  }

  closeModel() {
    if (this.closeCallback) {
      this.closeCallback();
    }
  }
}
// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

import { Component, OnInit, ViewChild, Input } from '@angular/core';

import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { AccountService } from '../../../services/account.service';
import { Utilities } from '../../../services/utilities';
import { User } from '../../../models/user.model';
import { UserEdit } from '../../../models/user-edit.model';
import { Role } from '../../../models/role.model';
import { Permission } from '../../../models/permission.model';

@Component({
  selector: 'vehicle-create',
  templateUrl: './vehicle-create.component.html',
  styleUrls: ['./vehicle-create.component.scss']
})
export class VehicleCreateComponent implements OnInit {

  public isEditMode = false;
  public isNewUser = false;
  public taskEdit: any = {};
  public formResetToggle = true;
  public modalHide = false;

  public changesSavedCallback: () => void;
  public changesFailedCallback: () => void;
  public changesCancelledCallback: () => void;
  public closeCallback: () => void;

  @Input()
  isViewOnly: boolean;

  @Input()
  isGeneralEditor = false;

  constructor(private alertService: AlertService) {
  }

  ngOnInit() {


  }

  showErrorAlert(caption: string, message: string) {
    this.alertService.showMessage(caption, message, MessageSeverity.error);
  }
  
  save(){

  }

  closeModel() {
    if (this.closeCallback) {
      this.closeCallback();
    }
  }

}
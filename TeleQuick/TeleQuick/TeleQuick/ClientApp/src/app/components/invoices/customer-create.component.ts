// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

import { Component, OnInit, ViewChild, Input } from '@angular/core';

import { AlertService, MessageSeverity } from '../../services/alert.service';
import { AccountService } from '../../services/account.service';
import { Utilities } from '../../services/utilities';
import { Role } from '../../models/role.model';
import { Permission } from '../../models/permission.model';


@Component({
  selector: 'customer-create',
  templateUrl: './customer-create.component.html',
  styleUrls: ['./customer-create.component.scss']
})
export class CustomerCreateComponent  {
  formResetToggle = true;
  taskEdit: any = {};
  @Input()
  isGeneralEditor = false;

  constructor(private alertService: AlertService) {
  }

  showErrorAlert(caption: string, message: string) {
    this.alertService.showMessage(caption, message, MessageSeverity.error);
  }

  save() {

  }
}





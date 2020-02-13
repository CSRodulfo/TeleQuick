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
  selector: 'vehicles-edit',
  templateUrl: './vehicle-edit.component.html',
  styleUrls: ['./vehicle-edit.component.scss']
})

export class VehicleEditComponent implements OnInit {

    public isEditMode = false;
    public isNewUser = false;
  
    public formResetToggle = true;
  
    public changesSavedCallback: () => void;
    public changesFailedCallback: () => void;
    public changesCancelledCallback: () => void;
  
    @Input()
    isViewOnly: boolean;
  
    @Input()
    isGeneralEditor = false;

  
    constructor(private alertService: AlertService, private accountService: AccountService) {
    }
  
    ngOnInit() {
 
    }
}
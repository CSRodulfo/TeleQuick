// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

import { fadeInOut } from '../../services/animations';
import { Component, OnInit, AfterViewInit, TemplateRef, ViewChild, Input } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';

import { AlertService, DialogType, MessageSeverity } from '../../services/alert.service';
import { AppTranslationService } from '../../services/app-translation.service';
import { BusinessService } from '../../services/business.service';
import { Utilities } from '../../services/utilities';
import { Vehicle } from '../../models/vehicle.model';
import { VehicleEditComponent } from './vehicle-edit/vehicle-edit.component';
import { Permission } from '../../models/permission.model';
import { UserEdit } from '../../models/user-edit.model';

@Component({
    selector: 'vehicles-management',
    templateUrl: './vehicles-management.component.html',
    styleUrls: ['./vehicles-management.component.scss'],
    animations: [fadeInOut]
})

export class VehiclesManagementComponent implements OnInit {
    columns: any[] = [];
    rows: Vehicle[] = [];
    rowsCache: Vehicle[] = [];
    editedUser: UserEdit;
    sourceUser: UserEdit;
    editingUserName: { name: string };
    loadingIndicator: boolean;

    @ViewChild('indexTemplate', { static: true })
    indexTemplate: TemplateRef<any>;

    @ViewChild('actionsTemplate', { static: true })
    actionsTemplate: TemplateRef<any>;

    @ViewChild('editorModal', { static: true })
    editorModal: ModalDirective;

    @ViewChild('vehicleEditor', { static: true })
    vehicleEditor: VehicleEditComponent;

    constructor(private alertService: AlertService, private translationService: AppTranslationService,
        private businessService: BusinessService) {
    }

    ngOnInit() {

        const gT = (key: string) => this.translationService.getTranslation(key);

        this.columns = [
            { prop: 'index', name: '#', width: 40, cellTemplate: this.indexTemplate, canAutoResize: false },
            { prop: 'make', name: gT('vehicles.management.Make'), width: 50 },
            { prop: 'model', name: gT('vehicles.management.Model'), width: 90, },
            { prop: 'year', name: gT('vehicles.management.Year'), width: 120 },
            { prop: 'registrationNumber', name: gT('vehicles.management.RegistrationNumber'), width: 140 },
        ];

        // if (this.canManageVehicles) {
        this.columns.push({ name: '', width: 160, cellTemplate: this.actionsTemplate, resizeable: false, canAutoResize: false, sortable: false, draggable: false });
        //}

        this.loadData();
    }


    ngAfterViewInit() {

        this.vehicleEditor.changesSavedCallback = () => {
            this.loadData();
            this.editorModal.hide();
        };

        this.vehicleEditor.changesCancelledCallback = () => {
            this.loadData();
            this.editedUser = null;
            this.sourceUser = null;
            this.editorModal.hide();
        };
    }


    //addNewUserToList() {
    //    if (this.sourceUser) {
    //        Object.assign(this.sourceUser, this.editedUser);

    //        let sourceIndex = this.rowsCache.indexOf(this.sourceUser, 0);
    //        if (sourceIndex > -1) {
    //            Utilities.moveArrayItem(this.rowsCache, sourceIndex, 0);
    //        }

    //        sourceIndex = this.rows.indexOf(this.sourceUser, 0);
    //        if (sourceIndex > -1) {
    //            Utilities.moveArrayItem(this.rows, sourceIndex, 0);
    //        }

    //        this.editedUser = null;
    //        this.sourceUser = null;
    //    } else {
    //        const user = new User();
    //        Object.assign(user, this.editedUser);
    //        this.editedUser = null;

    //        let maxIndex = 0;
    //        for (const u of this.rowsCache) {
    //            if ((u as any).index > maxIndex) {
    //                maxIndex = (u as any).index;
    //            }
    //        }

    //        (user as any).index = maxIndex + 1;

    //        this.rowsCache.splice(0, 0, user);
    //        this.rows.splice(0, 0, user);
    //        this.rows = [...this.rows];
    //    }
    //}


    loadData() {
        this.alertService.startLoadingMessage();
        this.loadingIndicator = true;

        this.businessService.getVehicles().subscribe(results => this.onDataLoadSuccessful(results), error => this.onDataLoadFailed(error));
    }

    onDataLoadSuccessful(vehicles: Vehicle[]) {
        this.alertService.stopLoadingMessage();
        this.loadingIndicator = false;

        vehicles.forEach((user, index, vehicles) => {
            (user as any).index = index + 1;
        });

        this.rowsCache = [...vehicles];
        this.rows = vehicles;
    }

    onDataLoadFailed(error: any) {
        this.alertService.stopLoadingMessage();
        this.loadingIndicator = false;

        this.alertService.showStickyMessage('Load Error', `Unable to retrieve vehicles from the server.\r\nErrors: "${Utilities.getHttpResponseMessages(error)}"`,
            MessageSeverity.error, error);
    }


    onSearchChanged(value: string) {
        this.rows = this.rowsCache.filter(r => Utilities.searchArray(value, false, r.make, r.model, r.year, r.registrationNumber));
    }

    newUser() {
        this.editingUserName = null;
        this.sourceUser = null;
        //this.editedUser = this.userEditor.newUser(this.allRoles);
        this.editorModal.show();
    }

    onEditorModalHidden() {
        //this.editingUserName = null;
        //this.userEditor.resetForm(true);
      }


    //  editUser(row: UserEdit) {
    //      this.editingUserName = { name: row.userName };
    //      this.sourceUser = row;
    //      this.editedUser = this.userEditor.editUser(row, this.allRoles);
    //      this.editorModal.show();
    //  }


    //  deleteUser(row: UserEdit) {
    //      this.alertService.showDialog('Are you sure you want to delete \"' + row.userName + '\"?', DialogType.confirm, () => this.deleteUserHelper(row));
    //  }


    //  deleteUserHelper(row: UserEdit) {

    //      this.alertService.startLoadingMessage('Deleting...');
    //      this.loadingIndicator = true;

    //      this.accountService.deleteUser(row)
    //          .subscribe(results => {
    //              this.alertService.stopLoadingMessage();
    //              this.loadingIndicator = false;

    //              this.rowsCache = this.rowsCache.filter(item => item !== row);
    //              this.rows = this.rows.filter(item => item !== row);
    //          },
    //          error => {
    //              this.alertService.stopLoadingMessage();
    //              this.loadingIndicator = false;

    //              this.alertService.showStickyMessage('Delete Error', `An error occured whilst deleting the user.\r\nError: "${Utilities.getHttpResponseMessages(error)}"`,
    //                  MessageSeverity.error, error);
    //          });
    //  }

    get canManageVehicles() {
        return true;
    }
}

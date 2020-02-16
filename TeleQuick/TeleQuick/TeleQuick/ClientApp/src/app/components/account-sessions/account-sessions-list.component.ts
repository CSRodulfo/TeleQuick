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
import { AccountSession } from '../../models/account-session.model';
import { AccountSessionsEditComponent } from './account-sessions-edit/account-sessions-edit.component';
import { AccountSessionsCreateComponent } from './account-sessions-create/account-sessions-create.component';
import { GlobalResources } from '../../services/globalResources'

@Component({
  selector: 'account-sessions-list',
  templateUrl: './account-sessions-list.component.html',
  styleUrls: ['./account-sessions-list.component.scss'],
  animations: [fadeInOut]
})

export class AccountSessionsComponent implements OnInit {
  columns: any[] = [];
  rows: AccountSession[] = [];
  rowsCache: AccountSession[] = [];
  loadingIndicator: boolean;

  @ViewChild('indexTemplate', { static: true })
  indexTemplate: TemplateRef<any>;

  @ViewChild('actionsTemplate', { static: true })
  actionsTemplate: TemplateRef<any>;

  @ViewChild('editorModal', { static: true })
  editorModal: ModalDirective;

  @ViewChild('createModal', { static: true })
  createModal: ModalDirective;

  @ViewChild('accountSessionEditor', { static: true })
  vehicleEditor: AccountSessionsEditComponent;

  @ViewChild('accountSessionCreate', { static: true })
  vehicleCreate: AccountSessionsCreateComponent;

  constructor(private alertService: AlertService, private translationService: AppTranslationService,
    private businessService: BusinessService, private globalResource: GlobalResources) {
  }

  ngOnInit() {

    const gT = (key: string) => this.translationService.getTranslation(key);

    this.columns = [
      { prop: 'index', name: '#', width: 40, cellTemplate: this.indexTemplate, canAutoResize: false },
      { prop: 'loginUser', name: gT('vehicles.management.Make'), width: 100 },
      { prop: 'loginUserPassword', name: gT('vehicles.management.Model'), width: 100 },
      //{ prop: 'year', name: gT('vehicles.management.Year'), width: 80 },
      //{ prop: 'registrationNumber', name: gT('vehicles.management.RegistrationNumber'), width: 80 },
    ];

    // if (this.canManageVehicles) {
    this.columns.push({ name: '', width: 200, cellTemplate: this.actionsTemplate, resizeable: false, canAutoResize: false, sortable: false, draggable: false });
    //}

    this.loadData();
  }

  ngAfterViewInit() {

  // this.vehicleEditor.changesSavedCallback = () => {
  //   this.loadData();
  //   this.editorModal.hide();
  // };

  // this.vehicleEditor.changesCancelledCallback = () => {
  //   this.editorModal.hide();
  // };

  // this.vehicleCreate.changesSavedCallback = () => {
  //   this.loadData();
  //   this.createModal.hide();
  // };

  // this.vehicleCreate.changesCancelledCallback = () => {
  //   this.createModal.hide();
  // };
  }

  loadData() {
    this.alertService.startLoadingMessage();
    this.loadingIndicator = true;

    //this.businessService.getVehicles().subscribe(results => this.onDataLoadSuccessful(results),
    // error => this.onDataLoadFailed(error));
  }

  onDataLoadSuccessful(vehicles: AccountSession[]) {
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

    this.alertService.showStickyMessage('Error cargando', `No se puedo recibir informacion \r\nErrors: "${Utilities.getHttpResponseMessages(error)}"`,
      MessageSeverity.error, error);
  }


  onSearchChanged(value: string) {
   // this.rows = this.rowsCache.filter(r => Utilities.searchArray(value, false, r.make, r.model, r.year, r.registrationNumber));
  }

  createVehicle() {
    this.createModal.show();
  }

  editVehicle(row: AccountSession) {
    //Object.assign(this.accountSessionEditor.entityVehicle, row);
    this.editorModal.show();
  }

  deleteVehicle(row: AccountSession) {

    //this.alertService.showDialog(this.globalResource.error + row.model + '\"?', DialogType.confirm, () => this.deleteUserHelper(row));
  }

 //deleteUserHelper(row: AccountSession) {
 //  this.alertService.startLoadingMessage('Eliminando...');
 //  this.loadingIndicator = true;
 //  this.businessService.deleteVehicle(row)
 //    .subscribe(
 //      results => {
 //        this.alertService.stopLoadingMessage();
 //        this.loadingIndicator = false;
 //        //this.rowsCache = this.rowsCache.filter(item => item !== row);
 //        //this.rows = this.rows.filter(item => item !== row);
 //        this.loadData();
 //      },
 //      error => {
 //        this.alertService.stopLoadingMessage();
 //        this.loadingIndicator = false;
 //        this.alertService.showStickyMessage('Error al eliminar', `Ha ocurrido un error al elimiar el vehiculo\r\nError: "${Utilities.getHttpResponseMessages(error)}"`,
 //          MessageSeverity.error, error);
 //      });
 // }

  canManageVehicles() {
    return true;
  }
}

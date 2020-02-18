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

  @ViewChild('validTemplate', { static: true })
  validTemplate: TemplateRef<any>;


  @ViewChild('actionsTemplate', { static: true })
  actionsTemplate: TemplateRef<any>;

  @ViewChild('editorModal', { static: true })
  editorModal: ModalDirective;

  @ViewChild('createModal', { static: true })
  createModal: ModalDirective;

  @ViewChild('accountSessionEditor', { static: true })
  accountSessionEditor: AccountSessionsEditComponent;

  @ViewChild('accountSessionCreate', { static: true })
  accountSessionCreate: AccountSessionsCreateComponent;

  constructor(private alertService: AlertService, private translationService: AppTranslationService,
    private businessService: BusinessService, private resx: GlobalResources) {
  }

  ngOnInit() {

    this.columns = [
      { prop: 'index', name: '#', width: 40, cellTemplate: this.indexTemplate, canAutoResize: false },
      { prop: 'loginUser', name: 'Cuenta Usuario', width: 100 },
      { prop: 'loginUserPassword', name: 'Contraseña', width: 100 },
      { prop: 'isValid', name: 'Conexión', width: 100, cellTemplate: this.validTemplate },
      { prop: 'concessionaryName', name: 'Concesionaria', width: 100 },
      //{ prop: 'year', name: gT('vehicles.management.Year'), width: 80 },
      //{ prop: 'registrationNumber', name: gT('vehicles.management.RegistrationNumber'), width: 80 },
    ];

    // if (this.canManageVehicles) {
    this.columns.push({ name: '', width: 200, cellTemplate: this.actionsTemplate, resizeable: false, canAutoResize: false, sortable: false, draggable: false });
    //}

    this.loadData();
  }

  ngAfterViewInit() {

    this.accountSessionEditor.changesSavedCallback = () => {
      this.loadData();
      this.editorModal.hide();
    };

    this.accountSessionEditor.changesCancelledCallback = () => {
      this.editorModal.hide();
    };

    this.accountSessionCreate.changesSavedCallback = () => {
      this.loadData();
      this.createModal.hide();
    };

    this.accountSessionCreate.changesCancelledCallback = () => {
      this.createModal.hide();
    };
  }

  loadData() {
    this.alertService.startLoadingMessage();
    this.loadingIndicator = true;

    this.businessService.getAccountSession().subscribe(results => this.onDataLoadSuccessful(results),
      error => this.onDataLoadFailed(error));
  }

  onDataLoadSuccessful(accountSession: AccountSession[]) {
    this.alertService.stopLoadingMessage();
    this.loadingIndicator = false;

    accountSession.forEach((user, index, vehicles) => {
      (user as any).index = index + 1;
    });

    this.rowsCache = [...accountSession];
    this.rows = accountSession;
  }

  onDataLoadFailed(error: any) {
    this.alertService.stopLoadingMessage();
    this.loadingIndicator = false;

    this.alertService.showStickyMessage(this.resx.loadError, `${this.resx.loadErrorDetail} ${Utilities.getHttpResponseMessages(error)}"`,
      MessageSeverity.error, error);
  }


  onSearchChanged(value: string) {
    this.rows = this.rowsCache.filter(r => Utilities.searchArray(value, false, r.loginUser, r.concessionaryName));
  }

  createVehicle() {
    this.createModal.show();
  }

  editVehicle(row: AccountSession) {
    Object.assign(this.accountSessionEditor.entityAccountSession, row);
    this.editorModal.show();
  }

  deleteVehicle(row: AccountSession) {
    this.alertService.showDialog(this.resx.deleteWarning + row.loginUser + '\"?', DialogType.confirm, () => this.deleteUserHelper(row));
  }

  deleteUserHelper(row: AccountSession) {
    this.alertService.startLoadingMessage(this.resx.deleteWarning);
    this.loadingIndicator = true;
    this.businessService.deleteAccountSession(row)
      .subscribe(
        results => {
          this.alertService.stopLoadingMessage();
          this.loadingIndicator = false;
          //this.rowsCache = this.rowsCache.filter(item => item !== row);
          //this.rows = this.rows.filter(item => item !== row);
          this.loadData();
        },
        error => {
          this.alertService.stopLoadingMessage();
          this.loadingIndicator = false;
          this.alertService.showStickyMessage(this.resx.deleteError, `"${this.resx.deleteErrorDetail} ${Utilities.getHttpResponseMessages(error)}"`,
            MessageSeverity.error, error);
        });
  }

  canManageVehicles() {
    return true;
  }
}

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
import { VehicleCreateComponent } from './vehicle-create/vehicle-create.component';
import { FakeMissingTranslationHandler } from '@ngx-translate/core';
import {GlobalResources} from '../../services/globalResources'

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
    loadingIndicator: boolean;

    @ViewChild('indexTemplate', { static: true })
    indexTemplate: TemplateRef<any>;

    @ViewChild('actionsTemplate', { static: true })
    actionsTemplate: TemplateRef<any>;

    @ViewChild('editorModal', { static: true })
    editorModal: ModalDirective;

    @ViewChild('createModal', { static: true })
    createModal: ModalDirective;

    @ViewChild('vehicleEditor', { static: true })
    vehicleEditor: VehicleEditComponent;

    @ViewChild('vehicleCreate', { static: true })
    vehicleCreate: VehicleCreateComponent;

    constructor(private alertService: AlertService, private translationService: AppTranslationService,
        private businessService: BusinessService, private globalResource: GlobalResources) {
    }

    ngOnInit() {

        const gT = (key: string) => this.translationService.getTranslation(key);

        this.columns = [
            { prop: 'index', name: '#', width: 40, cellTemplate: this.indexTemplate, canAutoResize: false },
            { prop: 'make', name: gT('vehicles.management.Make'), width: 100 },
            { prop: 'model', name: gT('vehicles.management.Model'), width: 100 },
            { prop: 'year', name: gT('vehicles.management.Year'), width: 80 },
            { prop: 'registrationNumber', name: gT('vehicles.management.RegistrationNumber'), width: 80 },
        ];

        // if (this.canManageVehicles) {
        this.columns.push({ name: '', width: 200, cellTemplate: this.actionsTemplate, resizeable: false, canAutoResize: false, sortable: false, draggable: false });
        //}

        this.loadData();
    }

    ngAfterViewInit() {

        this.vehicleEditor.changesSavedCallback = () => {
            this.loadData();
            this.editorModal.hide();
        };

        this.vehicleEditor.changesCancelledCallback = () => {
            this.editorModal.hide();
        };

        this.vehicleCreate.changesSavedCallback = () => {
            this.loadData();
            this.createModal.hide();
        };

        this.vehicleCreate.changesCancelledCallback = () => {
            this.createModal.hide();
        };
    }

    loadData() {
        this.alertService.startLoadingMessage();
        this.loadingIndicator = true;

        this.businessService.getVehicles().subscribe(results => this.onDataLoadSuccessful(results),
            error => this.onDataLoadFailed(error));
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

        this.alertService.showStickyMessage('Error cargando', `No se puedo recibir informacion \r\nErrors: "${Utilities.getHttpResponseMessages(error)}"`,
            MessageSeverity.error, error);
    }


    onSearchChanged(value: string) {
        this.rows = this.rowsCache.filter(r => Utilities.searchArray(value, false, r.make, r.model, r.year, r.registrationNumber));
    }

    createVehicle() {
        this.createModal.show();
    }

    editVehicle(row: Vehicle) {
        Object.assign(this.vehicleEditor.entityVehicle, row);
        this.editorModal.show();
    }

    deleteVehicle(row: Vehicle) {
        
        this.alertService.showDialog(this.globalResource.error + row.model + '\"?', DialogType.confirm, () => this.deleteUserHelper(row));
    }

    deleteUserHelper(row: Vehicle) {
        this.alertService.startLoadingMessage('Eliminando...');
        this.loadingIndicator = true;
        this.businessService.deleteVehicle(row)
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
                    this.alertService.showStickyMessage('Error al eliminar', `Ha ocurrido un error al elimiar el vehiculo\r\nError: "${Utilities.getHttpResponseMessages(error)}"`,
                        MessageSeverity.error, error);
                });
    }

    canManageVehicles() {
        return true;
    }
}

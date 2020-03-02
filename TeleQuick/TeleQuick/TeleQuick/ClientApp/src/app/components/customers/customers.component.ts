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
import { InvoiceHeader } from '../../models/invoice-header.model';
import { GlobalResources } from '../../services/globalResources';

@Component({
  selector: 'customers-list',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss'],
  animations: [fadeInOut]
})

export class CustomersComponent implements OnInit {
  columns: any[] = [];
  rows: InvoiceHeader[] = [];
  rowsCache: InvoiceHeader[] = [];
  loadingIndicator: boolean;
  force: any = 'force';

  @ViewChild('indexTemplate', { static: true })
  indexTemplate: TemplateRef<any>;

  @ViewChild('validTemplate', { static: true })
  validTemplate: TemplateRef<any>;

  @ViewChild('nameTemplate', { static: true })
  nameTemplate: TemplateRef<any>;

  @ViewChild('actionsTemplate', { static: true })
  actionsTemplate: TemplateRef<any>;

  constructor(private alertService: AlertService, private translationService: AppTranslationService,
    private businessService: BusinessService, private resx: GlobalResources) {
  }

  ngOnInit() {
    this.columns = [
      { prop: 'index', name: '#', width: 40, cellTemplate: this.indexTemplate, canAutoResize: false },
      { prop: 'date', name: 'Fecha', width: 100 },
      { prop: 'subTotal', name: 'Subtotal', width: 100, cellTemplate: this.nameTemplate },
      { prop: 'ivaIns', name: 'Iva', width: 100 },
      { prop: 'total', name: 'Total', width: 100 },
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


  }

  loadData() {
    this.alertService.startLoadingMessage();
    this.loadingIndicator = true;

    this.businessService.getInvoice().subscribe(results => this.onDataLoadSuccessful(results),
      error => this.onDataLoadFailed(error));
  }

  onDataLoadSuccessful(invoice: InvoiceHeader[]) {
    this.alertService.stopLoadingMessage();
    setTimeout(() => { this.loadingIndicator = false; }, 1500);

    invoice.forEach((user, index, vehicles) => {
      (user as any).index = index + 1;
    });

    this.rowsCache = [...invoice];
    this.rows = invoice;
  }

  onDataLoadFailed(error: any) {
    this.alertService.stopLoadingMessage();
    this.loadingIndicator = false;

    this.alertService.showStickyMessage(this.resx.loadError, `${this.resx.loadErrorDetail} ${Utilities.getHttpResponseMessages(error)}"`,
      MessageSeverity.error, error);
  }

  onSearchChanged(value: string) {
    this.rows = this.rowsCache.filter(r => Utilities.searchArray(value, false, r.date, r.concessionaryName));
  }

  canManageVehicles() {
    return true;
  }
}

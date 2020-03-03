import { fadeInOut } from '../../services/animations';
import { Component, OnInit, AfterViewInit, TemplateRef, ViewChild, Input } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';

import { AlertService, DialogType, MessageSeverity } from '../../services/alert.service';
import { AppTranslationService } from '../../services/app-translation.service';
import { BusinessService } from '../../services/business.service';
import { Utilities } from '../../services/utilities';
import { InvoiceDetail } from '../../models/invoice-detail.model';
import { GlobalResources } from '../../services/globalResources';

@Component({
  selector: 'registrations',
  templateUrl: './registrations.component.html',
  styleUrls: ['./registrations.component.scss'],
  animations: [fadeInOut]
})

export class RegistrationsComponent implements OnInit {
  columns: any[] = [];
  rows: InvoiceDetail[] = [];
  rowsCache: InvoiceDetail[] = [];
  loadingIndicator: boolean;
  force: any = 'force';
  selected: any[] = [];
  selectionType: any = 'single';

  messagesCustom = {
    emptyMessage: 'Sin datos para mostrar',
    totalMessage: 'Total',
    selectedMessage: ''
  };

  curPage: number = 1;
  pageSize: number = 10;
  rowCount: number = 36;

  @ViewChild('indexTemplate', { static: true })
  indexTemplate: TemplateRef<any>;

  @ViewChild('validTemplate', { static: true })
  validTemplate: TemplateRef<any>;

  @ViewChild('nameTemplate', { static: true })
  nameTemplate: TemplateRef<any>;

  @ViewChild('dateTemplate', { static: true })
  dateTemplate: TemplateRef<any>;

  @ViewChild('actionsTemplate', { static: true })
  actionsTemplate: TemplateRef<any>;

  constructor(private alertService: AlertService, private translationService: AppTranslationService,
    private businessService: BusinessService, private resx: GlobalResources) {
  }

  ngOnInit() {
    this.columns = [
      { prop: 'index', name: '#', width: 40, cellTemplate: this.indexTemplate, canAutoResize: false },
      { prop: 'date', name: 'Fecha', width: 100, cellTemplate: this.dateTemplate },
      { prop: 'hour', name: 'Hora', width: 100, cellTemplate: this.nameTemplate },
      { prop: 'quantity', name: 'Cantidad', width: 50 },
      { prop: 'tollStation', name: 'Paso', width: 200 },
      { prop: 'category', name: 'Categoria', width: 50 },
      { prop: 'total', name: 'Total', width: 50 },
      { prop: 'vehicleRegistration', name: 'Dominio', width: 100 },
    ];

    this.columns.push({ name: '', width: 200, cellTemplate: this.actionsTemplate, resizeable: false, canAutoResize: false, sortable: false, draggable: false });
    this.loadData();
  }

  ngAfterViewInit() {


  }

  loadData() {
    this.alertService.startLoadingMessage();
    this.loadingIndicator = true;
    console.log('Activate Loading');
    this.businessService.getInvoiceDetail().subscribe(results => this.onDataLoadSuccessful(results),
      error => this.onDataLoadFailed(error));
  }

  onDataLoadSuccessful(invoice: InvoiceDetail[]) {
    this.alertService.stopLoadingMessage();
    setTimeout(() => { this.loadingIndicator = false; }, 1500);

    invoice.forEach((invoice, index, invoices) => {
      (invoice as any).index = index + 1;
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
    this.rows = this.rowsCache.filter(r => Utilities.searchArray(value, false, r.date, r.vehicleRegistration));
  }

  canManageVehicles() {
    return true;
  }

  onSelect({ selected }) {
    console.log('Select Event', selected, this.selected);
  }
}

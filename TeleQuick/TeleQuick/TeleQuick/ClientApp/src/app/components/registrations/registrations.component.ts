import { fadeInOut } from '../../services/animations';
import { Component, OnInit, AfterViewInit, TemplateRef, ViewChild, Input } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { DatepickerModule } from 'ngx-bootstrap/datepicker';

import { AlertService, DialogType, MessageSeverity } from '../../services/alert.service';
import { AppTranslationService } from '../../services/app-translation.service';
import { BusinessService } from '../../services/business.service';
import { Utilities } from '../../services/utilities';
import { InvoiceDetail } from '../../models/invoice-detail.model';
import { GlobalResources } from '../../services/globalResources';
import { RegistrationListComponent } from './registration-list.component';

@Component({
  selector: 'registrations',
  templateUrl: './registrations.component.html',
  styleUrls: ['./registrations.component.scss'],
  animations: [fadeInOut]
})

export class RegistrationsComponent implements OnInit {
  loadingIndicator: boolean;
  searchValue: string;

  @ViewChild('dp', { static: true })
  bootstrapDatepicker: DatepickerModule;

  @ViewChild('gridRegistration', { static: true })
  gridRegistration: RegistrationListComponent;

  constructor(private alertService: AlertService, private translationService: AppTranslationService,
    private businessService: BusinessService, private resx: GlobalResources) {
  }

  ngOnInit() {
    this.gridRegistration.loadData();
  }

  ngAfterViewInit() {
  }

  onSearchChanged(value: string) {
    this.gridRegistration.onSearchChanged(value);
  }

  onActivate( selected ) {
    this.gridRegistration.loadData2(selected[0]);
  }
}

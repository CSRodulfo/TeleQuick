// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

import { fadeInOut } from '../../services/animations';
import { Component, OnInit, OnDestroy, Input, TemplateRef, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';

import { AuthService } from '../../services/auth.service';
import { AlertService, MessageSeverity, DialogType } from '../../services/alert.service';
import { AppTranslationService } from '../../services/app-translation.service';
import { Utilities } from '../../services/utilities';
import { BusinessService } from '../../services/business.service';

@Component({
  selector: 'products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss'],
  animations: [fadeInOut]
})

export class ProductsComponent implements OnInit {

  latestPosts = ['Nirva', 'pepe'];
  rows = [];
  rowsCache = [];
  columns = [];
  editing = {};
  taskEdit: any = {};
  isDataLoaded = false;
  loadingIndicator = true;
  formResetToggle = true;

  constructor(private alertService: AlertService, private translationService: AppTranslationService, private businessService: BusinessService) {
  }

  onSearchChanged(value: string) {
    this.rows = this.rowsCache.filter(r => Utilities.searchArray(value, false, r.name, r.description) || value == 'important' && r.important || value == 'not important' && !r.important);
  };

  ngOnInit() {
    this.loadingIndicator = true;


    this.loadData();

    this.isDataLoaded = true;

    setTimeout(() => { this.loadingIndicator = false; }, 1500);

    this.columns = [
      { prop: 'name', name: 'Tareas', cellTemplate: this.nameTemplate, width: 200 },
      { prop: 'description', name: 'Descripcion', cellTemplate: this.descriptionTemplate, width: 500, resizeable: false },
      { prop: 'tools', name: '', width: 80, cellTemplate: this.actionsTemplate, resizeable: false, canAutoResize: false, sortable: false, draggable: false }

    ];
  }

  loadData() {
    this.alertService.startLoadingMessage();
    this.loadingIndicator = true;

    this.businessService.getTest()
      .subscribe(results => {
        this.alertService.stopLoadingMessage();
        this.loadingIndicator = false;

        const roles  = Object.assign([], results);

        roles.forEach((role, index, roles) => {
          (role as any).index = index + 1;
      });


        this.rowsCache = [...roles];
        this.rows = roles;

      },
        error => {
          this.alertService.stopLoadingMessage();
          this.loadingIndicator = false;

          this.alertService.showStickyMessage('Load Error', `Unable to retrieve roles from the server.\r\nErrors: "${Utilities.getHttpResponseMessages(error)}"`,
            MessageSeverity.error, error);
        });
  }

  @ViewChild('nameTemplate', { static: true })
  nameTemplate: TemplateRef<any>;

  @ViewChild('descriptionTemplate', { static: true })
  descriptionTemplate: TemplateRef<any>;

  @ViewChild('actionsTemplate', { static: true })
  actionsTemplate: TemplateRef<any>;
}
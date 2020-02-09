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
import { LocalStoreManager } from '../../services/local-store-manager.service';
import { Utilities } from '../../services/utilities';

@Component({
    selector: 'products',
    templateUrl: './products.component.html',
    styleUrls: ['./products.component.scss'],
    animations: [fadeInOut]
})

export class ProductsComponent implements OnInit {

  latestPosts = ['Nirva', 'pepe'] ;
  rows = [];
  rowsCache = [];
  columns = [];
  editing = {};
  taskEdit: any = {};
  isDataLoaded = false;
  loadingIndicator = true;
  formResetToggle = true;



  onSearchChanged(value: string) {
      this.rows = this.rowsCache.filter(r => Utilities.searchArray(value, false, r.name, r.description) || value == 'important' && r.important || value == 'not important' && !r.important);
    };

  ngOnInit() {
    this.loadingIndicator = true;


      //this.refreshDataIndexes(data);
      this.rows = [
        { name: 'Create visual studio extension', description: 'Create a visual studio VSIX extension package that will add this project as an aspnet-core project template' },
        { name: 'Do a quick how-to writeup', description: '' },
        { name: 'Create aspnet-core/Angular8 tutorials based on this project', description: 'Create tutorials (blog/video/youtube) on how to build applications (full stack)' },
      ];
      //this.rowsCache = [...data];
      this.isDataLoaded = true;

      setTimeout(() => { this.loadingIndicator = false; }, 1500);
    
      
    this.columns = [
      { prop: 'name', name: 'Tareas', cellTemplate: this.nameTemplate, width: 200 },
      { prop: 'description', name: 'Descripcion', cellTemplate: this.descriptionTemplate, width: 500 },
    ];
  }

  
  refreshDataIndexes(data) {
    let index = 0;

    for (const i of data) {
      i.$$index = index++;
    }
  }
    
    @ViewChild('statusTemplate', { static: true })
    statusTemplate: TemplateRef<any>;
  
    @ViewChild('nameTemplate', { static: true })
    nameTemplate: TemplateRef<any>;
  
    @ViewChild('descriptionTemplate', { static: true })
    descriptionTemplate: TemplateRef<any>;
  
    @ViewChild('actionsTemplate', { static: true })
    actionsTemplate: TemplateRef<any>;
  
}

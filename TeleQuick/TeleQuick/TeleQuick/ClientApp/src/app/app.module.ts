// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

import { NgModule, ErrorHandler } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';

import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { OAuthModule, OAuthStorage } from 'angular-oauth2-oidc';
import { ToastaModule } from 'ngx-toasta';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { PopoverModule } from 'ngx-bootstrap/popover';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { ChartsModule } from 'ng2-charts';

import { AppRoutingModule } from './app-routing.module';
import { AppErrorHandler } from './app-error.handler';
import { AppTitleService } from './services/app-title.service';
import { AppTranslationService, TranslateLanguageLoader } from './services/app-translation.service';
import { ConfigurationService } from './services/configuration.service';
import { AlertService } from './services/alert.service';
import { ThemeManager } from './services/theme-manager';
import { LocalStoreManager } from './services/local-store-manager.service';
import { AuthStorage } from './services/auth-storage';
import { NotificationService } from './services/notification.service';
import { NotificationEndpoint } from './services/notification-endpoint.service';
import { AccountService } from './services/account.service';
import { AccountEndpoint } from './services/account-endpoint.service';
import { BusinessService } from './services/business.service';
import { BusinessEndpoint } from './services/business-endpoint.service';
import { GlobalResources } from './services/globalResources';

import { EqualValidator } from './directives/equal-validator.directive';
import { LastElementDirective } from './directives/last-element.directive';
import { AutofocusDirective } from './directives/autofocus.directive';
import { BootstrapTabDirective } from './directives/bootstrap-tab.directive';
import { BootstrapToggleDirective } from './directives/bootstrap-toggle.directive';
import { BootstrapSelectDirective } from './directives/bootstrap-select.directive';
import { BootstrapDatepickerDirective } from './directives/bootstrap-datepicker.directive';
import { GroupByPipe } from './pipes/group-by.pipe';

import { AppComponent } from './components/app.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { CustomersComponent } from './components/customers/customers.component';

import { ProcessComponent } from './components/process/process.component';
import { VehiclesManagementComponent } from './components/vehicles/vehicles-list.component';
import { VehicleEditComponent } from './components/Vehicles/vehicle-edit/vehicle-edit.component';
import { VehicleCreateComponent } from './components/Vehicles/vehicle-create/vehicle-create.component';
import { SettingsComponent } from './components/settings/settings.component';
import { AboutComponent } from './components/about/about.component';
import { NotFoundComponent } from './components/not-found/not-found.component';

import { BannerDemoComponent } from './components/controls/banner-demo.component';
import { StatisticsDemoComponent } from './components/controls/statistics-demo.component';
import { NotificationsViewerComponent } from './components/controls/notifications-viewer.component';
import { SearchBoxComponent } from './components/controls/search-box.component';
import { UserInfoComponent } from './components/controls/user-info.component';
import { CustomerCreateComponent } from './components/customers/customer-create.component';
import { UserPreferencesComponent } from './components/controls/user-preferences.component';
import { UsersManagementComponent } from './components/controls/users-management.component';
import { RolesManagementComponent } from './components/controls/roles-management.component';
import { RoleEditorComponent } from './components/controls/role-editor.component';

import { AccountSessionsComponent } from './components/account-sessions/account-sessions-list.component';
import { AccountSessionsEditComponent } from './components/account-sessions/account-sessions-edit/account-sessions-edit.component';
import { AccountSessionsCreateComponent } from './components/account-sessions/account-sessions-create/account-sessions-create.component';
import { ProgressbarModule } from 'ngx-bootstrap/progressbar';



@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useClass: TranslateLanguageLoader
      }
    }),
    NgxDatatableModule,
    OAuthModule.forRoot(),
    ToastaModule.forRoot(),
    TooltipModule.forRoot(),
    PopoverModule.forRoot(),
    BsDropdownModule.forRoot(),
    CarouselModule.forRoot(),
    ModalModule.forRoot(),
    ChartsModule,
    ProgressbarModule.forRoot()
  ],
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    CustomersComponent,
    AccountSessionsComponent,
    ProcessComponent,
    VehiclesManagementComponent, VehicleEditComponent,  VehicleCreateComponent,
    SettingsComponent,
    UsersManagementComponent, UserInfoComponent, UserPreferencesComponent,
    CustomerCreateComponent,
    RolesManagementComponent, RoleEditorComponent,
    AboutComponent,
    NotFoundComponent,
    NotificationsViewerComponent,
    SearchBoxComponent,
    StatisticsDemoComponent, BannerDemoComponent,
    EqualValidator,
    LastElementDirective,
    AutofocusDirective,
    BootstrapTabDirective,
    BootstrapToggleDirective,
    BootstrapSelectDirective,
    BootstrapDatepickerDirective,
    GroupByPipe,
    VehicleCreateComponent,
    AccountSessionsEditComponent,
    AccountSessionsCreateComponent
  ],
  providers: [
    { provide: ErrorHandler, useClass: AppErrorHandler },
    { provide: OAuthStorage, useClass: AuthStorage },
    AlertService,
    ThemeManager,
    ConfigurationService,
    AppTitleService,
    AppTranslationService,
    NotificationService,
    NotificationEndpoint,
    AccountService,
    AccountEndpoint,
    BusinessEndpoint,
    BusinessService,
    LocalStoreManager,
    GlobalResources
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}

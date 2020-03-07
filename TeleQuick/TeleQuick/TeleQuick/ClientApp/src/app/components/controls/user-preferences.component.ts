
import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AlertService, DialogType, MessageSeverity } from '../../services/alert.service';
import { ConfigurationService } from '../../services/configuration.service';
import { AppTranslationService } from '../../services/app-translation.service';
import { BootstrapSelectDirective } from '../../directives/bootstrap-select.directive';
import { AccountService } from '../../services/account.service';
import { ThemeManager } from '../../services/theme-manager';
import { Utilities } from '../../services/utilities';
import { Permission } from '../../models/permission.model';


@Component({
  selector: 'user-preferences',
  templateUrl: './user-preferences.component.html',
  styleUrls: ['./user-preferences.component.scss']
})
export class UserPreferencesComponent implements OnInit, OnDestroy {

  themeSelectorToggle = true;

  languageChangedSubscription: any;

  @ViewChild('languageSelector', { static: true })
  languageSelector: BootstrapSelectDirective;

  @ViewChild('homePageSelector', { static: true })
  homePageSelector: BootstrapSelectDirective;

  constructor(
    private alertService: AlertService,
    private translationService: AppTranslationService,
    private accountService: AccountService,
    public themeManager: ThemeManager,
    public configurations: ConfigurationService) {
  }

  ngOnInit() {
    this.languageChangedSubscription = this.translationService.languageChanged$.subscribe(data => {
      this.themeSelectorToggle = false;

      setTimeout(() => {
        this.languageSelector.refresh();
        this.homePageSelector.refresh();
        this.themeSelectorToggle = true;
      });
    });
  }

  ngOnDestroy() {
    this.languageChangedSubscription.unsubscribe();
  }



  reloadFromServer() {
    this.alertService.startLoadingMessage();

    this.accountService.getUserPreferences()
      .subscribe(results => {
        this.alertService.stopLoadingMessage();

        this.configurations.import(results);

        this.alertService.showMessage('Defaults loaded!', '', MessageSeverity.info);

      },
        error => {
          this.alertService.stopLoadingMessage();
          this.alertService.showStickyMessage('Load Error', `Unable to retrieve user preferences from the server.\r\nErrors: "${Utilities.getHttpResponseMessages(error)}"`,
            MessageSeverity.error, error);
        });
  }

  setAsDefault() {
    this.alertService.showDialog('Are you sure you want to set the current configuration as your new defaults?', DialogType.confirm,
      () => this.setAsDefaultHelper(),
      () => this.alertService.showMessage('Operation Cancelled!', '', MessageSeverity.default));
  }

  setAsDefaultHelper() {
    this.alertService.startLoadingMessage('', 'Saving new defaults');

    this.accountService.updateUserPreferences(this.configurations.export())
      .subscribe(response => {
        this.alertService.stopLoadingMessage();
        this.alertService.showMessage('New Defaults', 'Account defaults updated successfully', MessageSeverity.success);

      },
        error => {
          this.alertService.stopLoadingMessage();
          this.alertService.showStickyMessage('Save Error', `An error occured whilst saving configuration defaults.\r\nErrors: "${Utilities.getHttpResponseMessages(error)}"`,
            MessageSeverity.error, error);
        });
  }



  resetDefault() {
    this.alertService.showDialog('Are you sure you want to reset your defaults?', DialogType.confirm,
      () => this.resetDefaultHelper(),
      () => this.alertService.showMessage('Operation Cancelled!', '', MessageSeverity.default));
  }

  resetDefaultHelper() {
    this.alertService.startLoadingMessage('', 'Resetting defaults');

    this.accountService.updateUserPreferences(null)
      .subscribe(response => {
        this.alertService.stopLoadingMessage();
        this.configurations.import(null);
        this.alertService.showMessage('Defaults Reset', 'Account defaults reset completed successfully', MessageSeverity.success);

      },
        error => {
          this.alertService.stopLoadingMessage();
          this.alertService.showStickyMessage('Save Error', `An error occured whilst resetting configuration defaults.\r\nErrors: "${Utilities.getHttpResponseMessages(error)}"`,
            MessageSeverity.error, error);
        });
  }


  get canViewInvoices() {
    return this.accountService.userHasPermission(Permission.viewUsersPermission);
  }

  get canViewRegistrations() {
    return this.accountService.userHasPermission(Permission.viewUsersPermission);
  }

  get canViewAccountSessions() {
    return this.accountService.userHasPermission(Permission.viewUsersPermission);
  }

  get canViewProcess() {
    return this.accountService.userHasPermission(Permission.viewUsersPermission);
  }

  get canViewVehicles() {
    return this.accountService.userHasPermission(Permission.viewUsersPermission);
  }
}

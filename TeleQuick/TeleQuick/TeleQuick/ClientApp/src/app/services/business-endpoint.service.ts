
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { AuthService } from './auth.service';
import { EndpointBase } from './endpoint-base.service';
import { ConfigurationService } from './configuration.service';
import { Vehicle } from '../models/vehicle.model';
import { AccountSession } from '../models/account-session.model';


@Injectable()
export class BusinessEndpoint extends EndpointBase {

  private readonly _usersUrl: string = '/api/BaseData';
  private readonly _userByUserNameUrl: string = '/api/account/users/username';
  private readonly _vehiclesUrl: string = '/api/Vehicle/Vehicle';
  private readonly _accountSessionUrl: string = '/api/accountSession/accountSession';
  private readonly _accountSessionValidateUrl: string = '/api/accountSession/ValidateConection';
  private readonly _invoiceUrl: string = '/api/Invoice/Invoice';
  private readonly _invoiceDetailUrl: string = '/api/Invoice/InvoiceDetail';
  private readonly _processUrl: string = '/api/Process/Process';
  private readonly _registrationUrl: string = '/api/Registration/Invoice';
  private readonly _chartDataConcessionaryUrl: string = '/api/Home/ChartDataConcessionary';
  private readonly _chartDataVehicleUrl: string = '/api/Home/ChartDataVehicle';

  get usersUrl() { return this.configurations.baseUrl + this._usersUrl; }
  get userByUserNameUrl() { return this.configurations.baseUrl + this._userByUserNameUrl; }
  get vehiclesUrl() { return this.configurations.baseUrl + this._vehiclesUrl; }
  get accountSessionUrl() { return this.configurations.baseUrl + this._accountSessionUrl; }
  get accountSessionValidateUrl() { return this.configurations.baseUrl + this._accountSessionValidateUrl; }
  get invoiceUrl() { return this.configurations.baseUrl + this._invoiceUrl; }
  get invoiceDetailUrl() { return this.configurations.baseUrl + this._invoiceDetailUrl; }
  get processUrl() { return this.configurations.baseUrl + this._processUrl; }
  get registrationUrl() { return this.configurations.baseUrl + this._registrationUrl; }
  get chartDataConcessionaryUrl() { return this.configurations.baseUrl + this._chartDataConcessionaryUrl; }
  get chartDataVehicleUrl() { return this.configurations.baseUrl + this._chartDataVehicleUrl; }

  constructor(private configurations: ConfigurationService, http: HttpClient, authService: AuthService) {
    super(http, authService);
  }

  getTest<T>(): Observable<T> {
    const endpointUrl = `${this.usersUrl}`;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.getTest());
      }));
  }

  getUsersEndpoint<T>(page?: number, pageSize?: number): Observable<T> {
    const endpointUrl = page && pageSize ? `${this.usersUrl}/${page}/${pageSize}` : this.usersUrl;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.getUsersEndpoint(page, pageSize));
      }));
  }

  getVehicleEndpoint<T>(page?: number, pageSize?: number): Observable<T> {
    const endpointUrl = page && pageSize ? `${this.vehiclesUrl}/${page}/${pageSize}` : this.vehiclesUrl;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.getVehicleEndpoint(page, pageSize));
      }));
  }

  postVehicleEndpoint<T>(vehicle: Vehicle): Observable<T> {
    return this.http.post<T>(this.vehiclesUrl, vehicle, this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.postVehicleEndpoint(vehicle));
      }));
  }

  putVehicleEndpoint<T>(vehicle: Vehicle, vehicleId?: number): Observable<T> {
    const endpointUrl = vehicleId ? `${this.vehiclesUrl}/${vehicleId}` : this.vehiclesUrl;

    return this.http.put<T>(endpointUrl, JSON.stringify(vehicle), this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.putVehicleEndpoint(vehicle, vehicleId));
      }));
  }

  deleteVehicleEndpoint<T>(vehicleId?: number): Observable<T> {
    const endpointUrl = vehicleId ? `${this.vehiclesUrl}/${vehicleId}` : this.vehiclesUrl;

    return this.http.delete<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.deleteVehicleEndpoint(vehicleId));
      }));
  }

  getAccountSessionEndpoint<T>(): Observable<T> {
    const endpointUrl = `${this.accountSessionUrl}`;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.getAccountSessionEndpoint());
      }));
  }

  getAccountSessionValidateConectionEndpoint<T>(accountSession: AccountSession): Observable<T> {
    //const endpointUrl = accountSessionId ? `${this.accountSessionValidateCnnUrl}/${accountSessionId}` : this.accountSessionValidateCnnUrl;

    return this.http.put<T>(this.accountSessionValidateUrl, JSON.stringify(accountSession), this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.getAccountSessionValidateConectionEndpoint(accountSession));
      }));
  }

  postAccountSessionEndpoint<T>(accountSession: AccountSession): Observable<T> {
    return this.http.post<T>(this.accountSessionUrl, accountSession, this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.postAccountSessionEndpoint(accountSession));
      }));
  }

  putAccountSessionEndpoint<T>(accountSession: AccountSession, accountSessionId?: number): Observable<T> {
    const endpointUrl = accountSessionId ? `${this.accountSessionUrl}/${accountSessionId}` : this.accountSessionUrl;

    return this.http.put<T>(endpointUrl, JSON.stringify(accountSession), this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.putAccountSessionEndpoint(accountSession, accountSessionId));
      }));
  }

  deleteAccountSessionEndpoint<T>(accountSessionId?: number): Observable<T> {
    const endpointUrl = accountSessionId ? `${this.accountSessionUrl}/${accountSessionId}` : this.accountSessionUrl;

    return this.http.delete<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.deleteAccountSessionEndpoint(accountSessionId));
      }));
  }

  getInvoiceEndpoint<T>(page?: number, pageSize?: number): Observable<T> {
    const endpointUrl = page && pageSize ? `${this.invoiceUrl}/${page}/${pageSize}` : this.invoiceUrl;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.getAccountSessionEndpoint());
      }));
  }

  getInvoiceDetailEndpoint<T>(page?: number, pageSize?: number): Observable<T> {
    const endpointUrl = page && pageSize ? `${this.invoiceUrl}/${page}/${pageSize}` : this.registrationUrl;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.getInvoiceDetailEndpoint());
      }));
  }

  getInvoiceDetailByHeaderIdEndpoint<T>(idHeader?: number ): Observable<T> {
    const endpointUrl = idHeader ? `${this.invoiceDetailUrl}/${idHeader}` : this.invoiceDetailUrl;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.getInvoiceDetailEndpoint());
      }));
  }

  getProcessEndpoint<T>(): Observable<T> {
    const endpointUrl = `${this.processUrl}`;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.getProcessEndpoint());
      }));
  }

  getChartDataConcessionary<T>(): Observable<T> {
    const endpointUrl = `${this.chartDataConcessionaryUrl}`;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.getChartDataConcessionary());
      }));
  }

  getChartDataVehicle<T>(): Observable<T> {
    const endpointUrl = `${this.chartDataVehicleUrl}`;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.getChartDataVehicle());
      }));
  }
}

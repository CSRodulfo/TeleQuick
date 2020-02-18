// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

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
  private readonly _vehicles: string = '/api/Vehicle/Vehicle';
  private readonly _accountSession: string = '/api/accountSession/accountSession';
  private readonly _accountSessionValidateCnn: string = '/api/accountSession/ValidateConection';

  get usersUrl() { return this.configurations.baseUrl + this._usersUrl; }
  get userByUserNameUrl() { return this.configurations.baseUrl + this._userByUserNameUrl; }
  get vehiclesUrl() { return this.configurations.baseUrl + this._vehicles; }
  get accountSessionUrl() { return this.configurations.baseUrl + this._accountSession; }
  get accountSessionValidateCnnUrl() { return this.configurations.baseUrl + this._accountSessionValidateCnn; }

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

  getAccountSessionValidateConectionEndpoint<T>(accountSessionId?: number): Observable<T> {
    const endpointUrl = accountSessionId ? `${this.accountSessionValidateCnnUrl}/${accountSessionId}` : this.accountSessionValidateCnnUrl;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.getAccountSessionValidateConectionEndpoint());
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
}
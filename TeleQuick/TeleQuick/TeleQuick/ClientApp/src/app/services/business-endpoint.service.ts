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


@Injectable()
export class BusinessEndpoint extends EndpointBase {

  private readonly _usersUrl: string = '/api/BaseData';
  private readonly _userByUserNameUrl: string = '/api/account/users/username';
  private readonly _vehicles: string = '/api/Vehicle/Vehicle';

  get usersUrl() { return this.configurations.baseUrl + this._usersUrl; }
  get userByUserNameUrl() { return this.configurations.baseUrl + this._userByUserNameUrl; }
  get vehicles() { return this.configurations.baseUrl + this._vehicles; }


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
    const endpointUrl = page && pageSize ? `${this.vehicles}/${page}/${pageSize}` : this.vehicles;

    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.getUsersEndpoint(page, pageSize));
      }));
  }

  postVehicleEndpoint<T>(vehicle: Vehicle): Observable<T> {
    return this.http.post<T>(this.vehicles, vehicle, this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.postVehicleEndpoint(vehicle));
      }));
  }

  putVehicleEndpoint<T>(vehicle: Vehicle, vehicleId?: number): Observable<T> {
    const endpointUrl = vehicleId ? `${this.vehicles}/${vehicleId}` : this.vehicles;

    return this.http.put<T>(endpointUrl, JSON.stringify(vehicle), this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.putVehicleEndpoint(vehicle, vehicleId));
      }));
  }

  deleteVehicleEndpoint<T>(vehicleId?: number): Observable<T> {
    const endpointUrl = vehicleId ? `${this.vehicles}/${vehicleId}` : this.vehicles;

    return this.http.delete<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.deleteVehicleEndpoint(vehicleId));
      }));
  }
}
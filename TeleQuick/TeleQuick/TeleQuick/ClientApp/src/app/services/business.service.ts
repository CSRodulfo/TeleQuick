// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

import { Injectable } from '@angular/core';
import { Observable, Subject, forkJoin } from 'rxjs';
import { mergeMap, tap } from 'rxjs/operators';

import { BusinessEndpoint } from './business-endpoint.service';
import { AuthService } from './auth.service';
import { User } from '../models/user.model';
import { Test } from '../models/test.model';
import { Vehicle } from '../models/vehicle.model';
import { Permission, PermissionNames, PermissionValues } from '../models/permission.model';
import { AccountSession } from '../models/account-session.model';


export type RolesChangedOperation = 'add' | 'delete' | 'modify';

@Injectable()
export class BusinessService {
  public static readonly roleAddedOperation: RolesChangedOperation = 'add';
  public static readonly roleDeletedOperation: RolesChangedOperation = 'delete';
  public static readonly roleModifiedOperation: RolesChangedOperation = 'modify';

  constructor(
    private businessEndpoint: BusinessEndpoint) {

  }

  getTest() {
    return this.businessEndpoint.getTest<Test>();
  }

  getVehicles(page?: number, pageSize?: number) {
    return this.businessEndpoint.getVehicleEndpoint<Vehicle[]>(page, pageSize);
  }

  postVehicle(vehicle: Vehicle) {
    return this.businessEndpoint.postVehicleEndpoint<Vehicle[]>(vehicle);
  }

  putVehicle(vehicle: Vehicle) {
    return this.businessEndpoint.putVehicleEndpoint<Vehicle[]>(vehicle, vehicle.id);
  }

  deleteVehicle(vehicle: Vehicle) {
    return this.businessEndpoint.deleteVehicleEndpoint<Vehicle[]>(vehicle.id);
  }

  getAccountSession() {
    return this.businessEndpoint.getAccountSessionEndpoint<AccountSession[]>();
  }

  getAccountSessionValidateConection(accountSession: AccountSession) {
    return this.businessEndpoint.getAccountSessionValidateConectionEndpoint<AccountSession[]>(accountSession);
  }

  postAccountSession(accountSession: AccountSession) {
    return this.businessEndpoint.postAccountSessionEndpoint<AccountSession[]>(accountSession);
  }

  putAccountSession(accountSession: AccountSession) {
    return this.businessEndpoint.putAccountSessionEndpoint<AccountSession[]>(accountSession, accountSession.id);
  }

  deleteAccountSession(accountSession: AccountSession) {
    return this.businessEndpoint.deleteAccountSessionEndpoint<AccountSession[]>(accountSession.id);
  }

  // getUsersAndRoles(page?: number, pageSize?: number) {
  //
  //   return forkJoin(
  //     this.accountEndpoint.getUsersEndpoint<User[]>(page, pageSize),
  //     this.accountEndpoint.getRolesEndpoint<Role[]>());
  // }

}

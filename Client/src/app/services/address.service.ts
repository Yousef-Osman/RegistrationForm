import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Governate } from '../models/Governate';
import { City } from '../models/City';

@Injectable({
  providedIn: 'root'
})
export class AddressService {

  baseUrl: string = environment.apiBaseUrl + '/users';

  constructor(private http: HttpClient) { }

  getGovernates() {
    return this.http.get<Governate[]>(this.baseUrl + '/Governates');
  }

  getCitiesByGovernate(id: number) {
    return this.http.get<City[]>(this.baseUrl + '/Cities/' + id);
  }
}

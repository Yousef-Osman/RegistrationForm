import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/User';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl: string = environment.apiBaseUrl + '/users';

  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get<User[]>(this.baseUrl + '/getAll');
  }

  getUser(id: number) {
    return this.http.get<User>(this.baseUrl + '/get/' + id);
  }

  createUser(user: User): Observable<User> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this.http.post<User>(this.baseUrl + '/create', user, { headers });
  }
}

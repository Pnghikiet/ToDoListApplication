import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { User } from '../shared/model/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl


  constructor(private http: HttpClient) { }

  login(value : any)
  {
    return this.http.post<User>(this.baseUrl + 'account/login',value)
  }

  register(value : any)
  {
    return this.http.post<User>(this.baseUrl + 'account/register',value)
  }
}

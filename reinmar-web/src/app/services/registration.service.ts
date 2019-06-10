import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../model/user';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  constructor(public http: HttpClient) { }

  baseUrl: string = 'http://localhost:5001/api/User';

  register(user: User){
    console.log(user);
    return this.http.post(this.baseUrl, user);

  }
}

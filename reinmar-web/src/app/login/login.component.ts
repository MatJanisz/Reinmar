import { Component, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private _loginService: LoginService) { }

  failedLoggin = false;
  waitingForResponse = false;

  loginIn(login: string, password: string) {
    this.waitingForResponse = true;
    this._loginService.logIn({ login, password }).subscribe(
      (dane) => { this.waitingForResponse = false; },
      (err2) => { this.failedLoggin = true; this.waitingForResponse = false; }
    );
  }
}

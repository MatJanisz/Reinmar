import { Component, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'login-app',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  constructor(private _loginService: LoginService) { }

  failedLoggin = false;
  waitingForResponse = false;

  loginIn(login: string, password: string) {
    this.waitingForResponse = true;
    this._loginService.logIn({email: login, password: password }).subscribe(
      (dane) => { this.waitingForResponse = false; },
      (err2) => { this.failedLoggin = true; this.waitingForResponse = false; }
    );
  }
}

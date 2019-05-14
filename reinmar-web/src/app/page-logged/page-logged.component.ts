import { Component, OnInit } from '@angular/core';
import { LogoutService } from '../services/logout.service';
import { LoginService } from '../services/login.service';
import { User } from '../models/user';

@Component({
  selector: 'page-logged',
  templateUrl: './page-logged.component.html',
  styleUrls: ['./page-logged.component.scss']
})
export class PageLoggedComponent implements OnInit{


  username: string;

  ngOnInit(): void {
    this.username = JSON.parse(localStorage.getItem('currentUser')).name;
  }

  constructor(private _logoutService: LogoutService, private _loginService: LoginService) { }

  logOut() {
    this._logoutService.logOut();
  }

  onInit(){

  }
}

import { Component } from '@angular/core';
import { LogoutService } from '../services/logout.service';

@Component({
  selector: 'page-logged',
  templateUrl: './page-logged.component.html',
  styleUrls: ['./page-logged.component.scss']
})
export class PageLoggedComponent {

  constructor(private _logoutService: LogoutService) { }

  logOut() {
    this._logoutService.logOut();
  }
}

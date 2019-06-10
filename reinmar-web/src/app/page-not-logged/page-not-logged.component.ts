import { Component } from '@angular/core';

@Component({
  selector: 'page-not-logged',
  templateUrl: './page-not-logged.component.html',
  styleUrls: ['./page-not-logged.component.scss']
})
export class PageNotLoggedComponent {


  registrationMode = false;

  public switchToLogin(){
    this.registrationMode=false;
  }

  public switchToRegistration(){
    this.registrationMode = true;
  }
}

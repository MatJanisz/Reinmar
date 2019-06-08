import { Component, OnInit } from '@angular/core';
import { RegistrationService } from '../services/registration.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  constructor(private registrationService: RegistrationService) { }

  ngOnInit() {
  }

  registrationFailed = false;
  registrationSuccess = false;

  register(name: string, surname: string, email: string, password: string){
    
    this.registrationService.register({name, surname, email, password}).subscribe( res => {
      this.registrationSuccess = true;
    },
    err => { this.registrationFailed = true})
  }


}

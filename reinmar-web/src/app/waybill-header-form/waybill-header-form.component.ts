import { Component, Output, EventEmitter, Input, OnChanges } from '@angular/core';

import { WaybillHeaders } from '../waybill-header';

@Component({
  selector: 'app-waybill-header-form',
  templateUrl: './waybill-header-form.component.html',
  styleUrls: ['./waybill-header-form.component.css']
})
export class WaybillHeaderFormComponent implements OnChanges {


  @Input() addInprogress: boolean;

  @Output() packageToAdd = new EventEmitter();
  package: WaybillHeaders = {
    SitId:0,
    FullName : "",
    Email : "",
    PhoneNumber:"",
    StreetName:"",
    HouseNumber:"",
    City :"",
    PostalCode:"",
    InvoiceId:"",
    Date: new Date(Date.now()),
    Notes:"",
    CashOnDelivery: 0,
    OrderName:""
  };

  @Input() waitIsEmpty = {
    Name: false,
    Surname: false,
    Street: false,
    House: false,
    City: false,
    Notes: false,
    CashOrDelivery: false,
    OrderName: false
  };

  constructor() { }

  ngOnChanges(): void {
    // if (this.addInprogress == true) {
    //   this.package.FullName = "";
    //   this.package.Email = "";
    //   this.package.PhoneNumber = "";
    //   this.package.StreetName = "";
    //   this.package.HouseNumber = "";
    //   this.package.City = "";
    //   this.package.PostalCode = "";
    //   this.package.InvoiceId = "";
    //   this.package.Notes = "";
    //   this.package.OrderName = "";
    // }
  }
  
  onPackageChange(){
    this.packageToAdd.emit(this.package);
  }
}

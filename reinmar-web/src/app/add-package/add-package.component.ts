import { Component } from '@angular/core';
import { WaybillBody, WaybillHeaders } from '../waybill-header';
import { WaybillHeaderFormComponent } from '../waybill-header-form/waybill-header-form.component';
import { WaybillService } from '../services/waybill.service';
import { PackageService } from '../services/packages.service';

@Component({
  selector: 'app-add-package',
  templateUrl: './add-package.component.html',
  styleUrls: ['./add-package.component.scss']
})
export class AddPackageComponent {

  addInprogress: boolean = false;
  actualSitID: string = "";

  pallet: WaybillBody = {
    SitId: 0,
    Category: "",
    CargoName: "",
    Quantity: 0,
    Code: "",
    IsAssembly: true,
    IsCollection: true,
    Zone: 0,
    Service: "",
    WaybillHeaders: null,
    Status: [
      {
        id: 0,
        Location: "",
        Event: "",
        DateFrom: new Date(Date.now())
      }
    ]
  };

  canAdd: boolean = true;
  ourSinglePack: WaybillHeaders;
  waitIsEmpty = {
    Name: false,
    Email: false,
    StreetName: false,
    House: false,
    PhoneNumber: false,
    City: false,
    Notes: false,
    CashOnDelivery: false,
    OrderName: false
  };


  constructor(
    private _waybillService: WaybillService,
    private _packageServie: PackageService
  ) { }

  addPackage() {

    // Throw in waybillcomponent if some field are empty

    if (this.ourSinglePack != undefined) {
      if (this.ourSinglePack.FullName == "" || this.ourSinglePack.FullName == undefined) {
        this.waitIsEmpty.Name = true; this.canAdd = false;
      }
      else this.waitIsEmpty.Name = false;

      if (this.ourSinglePack.Email == "" || this.ourSinglePack.Email == undefined) {
        this.waitIsEmpty.Email = true; this.canAdd = false;
      }
      else this.waitIsEmpty.Email = false;

      if (this.ourSinglePack.HouseNumber == "" || this.ourSinglePack.HouseNumber == undefined) {
        this.waitIsEmpty.House = true; this.canAdd = false;
      }
      else this.waitIsEmpty.House = false;

      if (this.ourSinglePack.PhoneNumber == "" || this.ourSinglePack.PhoneNumber == undefined) {
        this.waitIsEmpty.PhoneNumber = true; this.canAdd = false;
      }
      else this.waitIsEmpty.PhoneNumber = false;

      if (this.ourSinglePack.StreetName == "" || this.ourSinglePack.StreetName == undefined) {
        this.waitIsEmpty.StreetName = true; this.canAdd = false;
      }
      else this.waitIsEmpty.StreetName = false;

      if (this.ourSinglePack.City == "" || this.ourSinglePack.City == undefined) {
        this.waitIsEmpty.City = true; this.canAdd = false;
      }
      else this.waitIsEmpty.City = false;

      if (this.ourSinglePack.Notes == "" || this.ourSinglePack.Notes == undefined) {
        this.waitIsEmpty.Notes = true; this.canAdd = false;
      }
      else this.waitIsEmpty.Notes = false;

      if (this.ourSinglePack.OrderName == "" || this.ourSinglePack.OrderName == undefined) {
        this.waitIsEmpty.OrderName = true; this.canAdd = false;
      }
      else this.waitIsEmpty.OrderName = false;


      // CHCECK if OrderName exist already




      if (this.canAdd == true) {
        this.addInprogress = true;
        // this.pallet.Status[0].Location = this.ourSinglePack.City;
        // this.pallet.Status[0].Event = "on way";
        this._waybillService.createWaybillHeader(this.pallet).subscribe((data) => {
          this.addInprogress = false;

          let resSTR = JSON.stringify(data);
          let resJSON = JSON.parse(resSTR);
          this.actualSitID = JSON.parse(resJSON._body).SitId;

          // this.snackbarService.add({
          //   msg: '<strong>Package added.</strong>',
          //   timeout: 1500,
          //   color: "#FFFFFF",
          //   background: "#28a745",
          //   action: {
          //     text: '',
          //     onClick: (snack) => {
          //       console.log('dismissed: ' + snack.id);

          //     },
          //   }
          // });
        },
          (err) => { this.addInprogress = false; }
        );
      }
      else {
        this.addInprogress = false;
        this.waitIsEmpty.OrderName = true;
      }
      this.canAdd = true;


    }
    else {
      this.waitIsEmpty.CashOnDelivery = true;
      this.waitIsEmpty.City = true;
      this.waitIsEmpty.Email = true;
      this.waitIsEmpty.House = true;
      this.waitIsEmpty.Name = true;
      this.waitIsEmpty.Notes = true;
      this.waitIsEmpty.OrderName = true;
      this.waitIsEmpty.PhoneNumber = true;
      this.waitIsEmpty.StreetName = true;
    }



  }

  updatePackageToAdd(pack) {
    this.ourSinglePack = pack;
    this.pallet.WaybillHeaders = pack;
    this.pallet.SitId = pack.SitId;
  }

}



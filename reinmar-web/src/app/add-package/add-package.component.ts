import { Component, ViewChild, ElementRef, OnInit } from '@angular/core';
import { WaybillHeaderFormComponent } from '../waybill-header-form/waybill-header-form.component';
import { WaybillService } from '../services/waybill.service';
import { PackageService } from '../services/packages.service';
import { Package } from '../model/package';

@Component({
  selector: 'app-add-package',
  templateUrl: './add-package.component.html',
  styleUrls: ['./add-package.component.scss']
})
export class AddPackageComponent {


  loadingSuccess: boolean = false;
  actualSitID: number;

  canAdd: boolean = true;
  package: Package;

  constructor(
    private _packageServie: PackageService
  ) { }

  addPackage(event: Package) {

    this._packageServie.addPackage(event).subscribe( res => {
      console.log(res);
    })


    }




  
}







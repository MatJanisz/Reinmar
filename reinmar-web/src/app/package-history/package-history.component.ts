import { Component, OnInit } from '@angular/core';
import { Package } from '../model/package';
import { PackageService } from '../services/packages.service';
import { pipe } from 'rxjs';
import { map } from 'rxjs/operators';
import { PackageHistory } from '../model/package-history';

@Component({
  selector: 'app-package-history',
  templateUrl: './package-history.component.html',
  styleUrls: ['./package-history.component.scss']
})
export class PackageHistoryComponent implements OnInit {

  constructor(private _packageService: PackageService) { }

  userPackages: PackageHistory[] = [];

  ngOnInit() {
    this._packageService.getPackageHistory().
    pipe(map( res=> {
      return res.map( myPackage => {
        let statusIndex = myPackage.statuses.length -1
        return {
          sitId: myPackage.sitId,
          orderName: myPackage.orderName,
          receiverFullName: myPackage.receiverFullName,
          date: new Date(myPackage.statuses[statusIndex].date),
          address: myPackage.streetName + " " + myPackage.houseNumber + ", " + myPackage.postalCode + ", " + myPackage.city,
          notes: myPackage.notes

        }
      })
    })).subscribe(
      res => {
        this.userPackages = res;
        console.log(res);
      }
    )
  }

}

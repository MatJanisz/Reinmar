import { Component, ViewChild, ElementRef, OnInit } from '@angular/core';
import { PackageService } from '../services/packages.service';

@Component({
  selector: 'track-package',
  templateUrl: './track-package.component.html',
  styleUrls: ['./track-package.component.scss']
})
export class TrackPackageComponent implements OnInit {

  constructor(private _packagesService: PackageService){}

  showDetails: boolean = false;

  packageId: string;


  @ViewChild("idinput") idInput: ElementRef;

  packageinformation = {
    Location: "",
    Event: "",
    Notes: "",
    Date: ""
  }
  ngOnInit(): void {

  }

  ngAfterViewInit() {
    console.log("afterinit");
    setTimeout(() => {
      console.log(this.idInput.nativeElement.focus());
    }, 1000);
  }


  onTrackDownClick(sitId:string) {
    this._packagesService.trackPackage(sitId).subscribe((pack)=>{
      let lenghtOfStatus = pack[0].Status.length -1;
      this.packageinformation = {
        Location: pack[0].Status[lenghtOfStatus].Location,
        Event: pack[0].Status[lenghtOfStatus].Event,
        Notes: pack[0].WaybillHeaders.Notes,
        Date: pack[0].Status[lenghtOfStatus].DateFrom
      }
      this.showDetails = true;
    });
  }

  findAnotherPack(){
    this.showDetails = false;
  }

}

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
    location: "",
    event: "",
    notes: "",
    date: ""
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
      let lenghtOfStatus = pack.statuses.length -1;
      this.packageinformation = {
        location: pack[0].status[lenghtOfStatus].location,
        event: pack[0].status[lenghtOfStatus].event,
        notes: pack.notes,
        date: pack[0].status[lenghtOfStatus].date
      }
      this.showDetails = true;
    });
  }

  findAnotherPack(){
    this.showDetails = false;
  }

}

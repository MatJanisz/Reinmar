import { Component, Output, EventEmitter, Input, OnChanges, ViewChild, ElementRef } from '@angular/core';

import { Package } from '../model/package';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-package-form',
  templateUrl: './waybill-header-form.component.html',
  styleUrls: ['./waybill-header-form.component.scss']
})
export class WaybillHeaderFormComponent implements OnChanges {


  @Input() addInprogress: boolean;

  @Output() packageToAdd: EventEmitter<Package> = new EventEmitter();
  package: Package;

  @Input() waitIsEmpty = {
  };

  @ViewChild("input1") idInput: ElementRef;

  editForm: FormGroup;


  

  ngOnInit(): void {
    console.log(this.idInput)
    this.idInput.nativeElement.focus();
    this.editForm = new FormGroup({
      receiverFullName: new FormControl('', Validators.required),
      phoneNumber: new FormControl('', Validators.required),
      country: new FormControl('', Validators.required),
      city: new FormControl('', Validators.required),
      postalCode: new FormControl('', Validators.required),
      streetName: new FormControl('', Validators.required),
      notes: new FormControl(''),
      houseNumber: new FormControl('', Validators.required),
      cashOnDelivery: new FormControl(''),
      orderName: new FormControl('', Validators.required)
    })
  }

  constructor() { }

  ngOnChanges(): void {
  }
  
  onPackageAdd(){
    console.log(this.editForm)
    this.packageToAdd.emit({
      receiverFullName: this.editForm.controls["receiverFullName"].value,
      phoneNumber: this.editForm.controls["phoneNumber"].value,
      country: this.editForm.controls["country"].value,
      city: this.editForm.controls["city"].value,
      postalCode: this.editForm.controls["postalCode"].value,
      streetName: this.editForm.controls["streetName"].value,
      notes: this.editForm.controls["notes"].value,
      houseNumber: this.editForm.controls["houseNumber"].value,
      orderName: this.editForm.controls["orderName"].value,
      cashOnDelivery: 1,
      statuses: [{location:  this.editForm.controls["city"].value,
      event: "Not delivered"}]
    });
  }
}

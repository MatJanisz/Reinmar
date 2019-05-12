import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WaybillHeaderFormComponent } from './waybill-header-form.component';

describe('WaybillHeaderFormComponent', () => {
  let component: WaybillHeaderFormComponent;
  let fixture: ComponentFixture<WaybillHeaderFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WaybillHeaderFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WaybillHeaderFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { Injectable } from '@angular/core';


// import 'rxjs/Rx';
import { Store } from '@ngrx/store';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { State } from '../redux/app.store';
import { Observable, of } from 'rxjs';
import { WaybillBody, WaybillHeaders } from '../model/waybill-header';


@Injectable()
export class WaybillService {

  url = 'http://localhost:5001/api/WaybillBody/Create';
  constructor(public http: HttpClient, private _store: Store<State>) { }

  createWaybillHeader(waybillBody: WaybillBody): Observable<WaybillHeaders> {

    const token = JSON.parse(localStorage.getItem('currentUser')).token;

    const httpOptions = { headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': `Bearer ` + token.token
    })}

    waybillBody.WaybillHeaders.Date = new Date(Date.now());
    waybillBody.Status[0].DateFrom = new Date(Date.now());

    return  this.http.post<WaybillHeaders>(this.url, waybillBody, httpOptions);
  }
}

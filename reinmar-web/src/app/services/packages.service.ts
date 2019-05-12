import { Injectable, OnInit, OnDestroy } from '@angular/core';
// import 'rxjs/Rx';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import { catchError, map, tap } from 'rxjs/operators';


@Injectable()
export class PackageService {

    baseUrl: string = 'http://localhost:5001/api/WaybillBody/GetBySitId/';

    constructor(public http: HttpClient) { }


    trackPackage(sitId: string) {

        const token = JSON.parse(localStorage.getItem('currentUser')).token;

        const httpOptions = { headers: new HttpHeaders({
            'Content-Type':  'application/json',
            'Authorization': `Bearer ` + token.token
          })}

        return this.http.get(this.baseUrl + sitId, httpOptions)
            .pipe(map(result => {
                return result;
            }));
    }

}
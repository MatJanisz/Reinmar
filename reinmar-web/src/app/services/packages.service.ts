import { Injectable, OnInit, OnDestroy } from '@angular/core';
// import 'rxjs/Rx';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import { catchError, map, tap } from 'rxjs/operators';
import { Package } from '../model/package';


@Injectable()
export class PackageService {

    baseUrl: string = 'http://localhost:5001/api/Package/GetBySitId/';

    constructor(public http: HttpClient) { }


    trackPackage(sitId: string): Observable<Package> {

        const token = JSON.parse(localStorage.getItem('currentUser')).token;

        const httpOptions = { headers: new HttpHeaders({
            'Content-Type':  'application/json',
            'Authorization': `Bearer ` + token.token
          })}

        return this.http.get<Package>(this.baseUrl + sitId, httpOptions);
    }

}
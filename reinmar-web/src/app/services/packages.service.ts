import { Injectable, OnInit, OnDestroy } from '@angular/core';
// import 'rxjs/Rx';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import { catchError, map, tap } from 'rxjs/operators';
import { Package } from '../model/package';


@Injectable()
export class PackageService {

    baseUrl: string = 'http://localhost:5001/api/Package/';

    constructor(public http: HttpClient) { }

    getSessionToken(){
        return JSON.parse(localStorage.getItem('currentUser')).token;
    }


    trackPackage(sitId: string): Observable<Package> {

        const httpOptions = { headers: new HttpHeaders({
            'Content-Type':  'application/json',
            'Authorization': `Bearer ` + this.getSessionToken()
          })}

        return this.http.post<Package>(this.baseUrl + sitId, httpOptions);
    }

    addPackage(newPackage: Package) {
        const httpOptions = { headers: new HttpHeaders({
            'Content-Type':  'application/json',
            'Authorization': `Bearer ` + this.getSessionToken()
          })}

          console.log(httpOptions)
        return this.http.post<Package>(this.baseUrl, newPackage, httpOptions);
    }

    getPackageHistory(): Observable<Package[]>{
        const httpOptions = { headers: new HttpHeaders({
            'Content-Type':  'application/json',
            'Authorization': `Bearer ` + this.getSessionToken()
          })}

          console.log(httpOptions)
        return this.http.get<Package[]>(this.baseUrl, httpOptions);
    }

}
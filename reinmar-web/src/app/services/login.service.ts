import { Injectable, OnInit, OnDestroy } from '@angular/core';
// import 'rxjs/Rx';
import { Store } from '@ngrx/store';
import { User } from '../models/user';
import { State } from '../redux/app.store';
import { SETUSER } from '../redux/users.actions';
import { HttpClient } from '@angular/common/http';
import { map, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';

@Injectable()
export class LoginService {

    token: string = '';
    user: User = {};
    baseUrl: string = 'http://localhost:5001/api/Account/LogIn';

    constructor(public http: HttpClient, private _store: Store<State>) { }

    getToken() {
        this.token = JSON.parse(localStorage.getItem('currentUser')).token;
        return this.token;
    }

    logIn(data: { login: string, password: string }) {
        return this.http.post(this.baseUrl, data)
            .pipe(tap<{name: string, token: string}>(result => {
                this.token = result.token;
                localStorage.setItem('currentUser', JSON.stringify({ token: this.token, name: data.login }));
                this.user.login = data.login;
                this._store.dispatch({ type: SETUSER, payload: this.user });
                return result
            }));
    }

}

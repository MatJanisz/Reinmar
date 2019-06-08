import { Injectable, OnInit, OnDestroy } from '@angular/core';
// import 'rxjs/Rx';
import { Store } from '@ngrx/store';
import { State } from '../redux/app.store';
import { SETUSER } from '../redux/users.actions';
import { HttpClient } from '@angular/common/http';
import { map, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { User } from '../model/user';
import { LoginRequest } from '../model/login-request';

@Injectable()
export class LoginService {

    token: string = '';
    loginRequest: LoginRequest = {email: "", password: ""};
    baseUrl: string = 'http://localhost:5001/api/User/login';

    constructor(public http: HttpClient, private _store: Store<State>) { }

    getToken() {
        this.token = JSON.parse(localStorage.getItem('currentUser')).token;
        return this.token;
    }

    logIn(data: { email: string, password: string }) {
        return this.http.post(this.baseUrl, data)
            .pipe(tap<{name: string, token: string}>(result => {
                this.token = result.token;
                localStorage.setItem('currentUser', JSON.stringify({ token: this.token, name: data.email }));
                this.loginRequest.email = this.loginRequest.email;
                this._store.dispatch({ type: SETUSER, payload: this.loginRequest });
                return result
            }));
    }

}

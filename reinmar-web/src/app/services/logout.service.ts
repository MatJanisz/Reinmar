import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

// import 'rxjs/Rx';
import { Store } from '@ngrx/store';
import { State } from '../redux/app.store';
import { LOGOUTUSER } from '../redux/users.actions';

@Injectable()
export class LogoutService {

  constructor(private _store: Store<State>) { }

  logOut() {
    localStorage.removeItem('currentUser');
    this._store.dispatch({ type: LOGOUTUSER, payload: null });
  }
}

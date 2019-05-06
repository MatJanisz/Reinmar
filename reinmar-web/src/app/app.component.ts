import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { State } from './redux/app.store';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  isLogged: boolean = false;

  constructor(private _store: Store<State>) {}

  ngOnInit(): void {

    this._store.select((state) => state.app.authenticated)
      .subscribe((authenticated) => {
        this.isLogged = authenticated;
      });
  }

}

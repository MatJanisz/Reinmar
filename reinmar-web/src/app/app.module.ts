import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

// components
import { AppComponent } from './app.component';

import { HttpModule } from '@angular/http';

// redux
import { userReducer } from './redux/users.reducers';


// router
import { routingModule } from './app.routing';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    routingModule,
    HttpModule,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

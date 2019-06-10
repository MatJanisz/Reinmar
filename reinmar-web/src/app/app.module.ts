import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

//ui components
import { ButtonsModule, WavesModule, IconsModule, NavbarModule, MDBBootstrapModule } from 'angular-bootstrap-md'

// components
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { AppDescriptionComponent } from './app-description/app-description.component';
import { PageNotLoggedComponent } from './page-not-logged/page-not-logged.component';
import { PageLoggedComponent } from './page-logged/page-logged.component';


import { TrackPackageComponent } from './track-package/track-package.component';
import { AddPackageComponent } from './add-package/add-package.component';
import { EditPackageComponent } from './edit-package/edit-package.component';
import { WaybillHeaderFormComponent } from './waybill-header-form/waybill-header-form.component';


// redux
import { userReducer } from './redux/users.reducers';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';


// router
import { routingModule } from './app.routing';
import { WaybillService } from './services/waybill.service';
import { LogoutService } from './services/logout.service';
import { LoginService } from './services/login.service';
import { PackageService } from './services/packages.service';
import { RegistrationComponent } from './registration/registration.component';
import { PackageHistoryComponent } from './package-history/package-history.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AppDescriptionComponent,
    PageNotLoggedComponent,
    PageLoggedComponent,
    TrackPackageComponent,
    AddPackageComponent,
    EditPackageComponent,
    WaybillHeaderFormComponent,
    RegistrationComponent,
    PackageHistoryComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    routingModule,
    HttpClientModule,
    
    MDBBootstrapModule.forRoot(),
    // ClipboardModule,
    // SnackbarModule.forRoot(),
    StoreModule.forRoot(
      {app: userReducer}
    ),
    StoreDevtoolsModule.instrument({
      maxAge: 5
    })
  ],
  providers: [LoginService, PackageService, WaybillService, LogoutService],
  bootstrap: [AppComponent]
})
export class AppModule { }

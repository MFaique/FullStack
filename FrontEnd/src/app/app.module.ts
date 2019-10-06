import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";
import { CookieService, CookieOptions } from "angular2-cookie/core";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './login/login.component';
import { ReactiveFormsModule, FormsModule } from "@angular/forms";

import {
  MatFormFieldModule,
  MatInputModule,
  MatTableModule,
  MatToolbarModule,
  MatDividerModule,
  MatIconModule,
  MatSidenavModule,
  MatListModule,
  MatCheckboxModule,
  MatButtonModule,
  MatCardModule,
  MatTabsModule,
  MatPaginatorModule,
  MatSelectModule,
  MatRadioModule,
  MatMenuModule
} from '@angular/material';
import { UserComponent } from './user/user.component';
import { HttpService } from 'src/services/http.service';
import { RegisterComponent } from './register/register.component';
import { TokenService } from 'src/services/token.service';
import { DataService } from 'src/services/data.service';
import { AuthGuard } from 'src/services/auth.guard.service';
import { AddressComponent } from './address/address.component';
import { AddressListComponent } from './address-list/address-list.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    UserComponent,
    RegisterComponent,
    AddressComponent,
    AddressListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatToolbarModule,
    MatDividerModule,
    MatIconModule,
    MatSidenavModule,
    MatListModule,
    MatCheckboxModule,
    MatButtonModule,
    MatCardModule,
    MatTabsModule,
    MatPaginatorModule,
    MatSelectModule,
    MatRadioModule,
    MatMenuModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [
    HttpService,
    CookieService,
    TokenService,
    AuthGuard,
    DataService,
    { provide: CookieOptions, useValue: {} }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

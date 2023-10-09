import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CommonModule } from '@angular/common';


import { HttpClientModule } from '@angular/common/http';


import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';


import { AppComponent } from './app.component';
import { TarjetaCreditoComponent } from './components/components/tarjeta-credito/tarjeta-credito.component';

import { HijoEjemploComponent } from './components/hijo-ejemplo/hijo-ejemplo.component';
import { authTokens } from "./interceptors/auth-token";
import { MenuComponent } from './components/views/menu/menu.component';
import { AppRoutingModule } from './app-routing.module';
@NgModule({
  declarations: [
    AppComponent,
    TarjetaCreditoComponent,
    HijoEjemploComponent,
    MenuComponent
  ],
  imports: [
    CommonModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(), // ToastrModule added
    HttpClientModule,
    AppRoutingModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    authTokens,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

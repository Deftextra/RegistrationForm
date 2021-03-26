import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RegistrationListComponent } from './components/registration-list/registration-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddressComponent } from './components/address/address.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { RegistrationFormComponent } from './components/Forms/registration-form/registration-form.component';

@NgModule({
  declarations: [
    AppComponent,
    RegistrationListComponent,
    AddressComponent,
    NavMenuComponent,
    RegistrationFormComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

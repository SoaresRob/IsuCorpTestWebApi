import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing/app-routing.module';
import {NgxPaginationModule} from 'ngx-pagination';
import {Ng2OrderModule} from 'ng2-order-pipe';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { ReservationComponent } from './reservation/reservation.component';
import { ShowReservationComponent } from './reservation/show-reservation/show-reservation.component';
import { AddEditReservationComponent } from './reservation/add-edit-reservation/add-edit-reservation.component';
import {SharedService} from './shared.service';

import{HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { ContactTypeComponent } from './contact-type/contact-type.component';
import { AddEditContactTypeComponent } from './contact-type/add-edit-contact-type/add-edit-contact-type.component';
import { ContactComponent } from './contact/contact.component';
import { AddEditContactComponent } from './contact/add-edit-contact/add-edit-contact.component';

@NgModule({
  declarations: [
    AppComponent,
    ReservationComponent,
    ShowReservationComponent,
    AddEditReservationComponent,
    ContactTypeComponent,
    AddEditContactTypeComponent,
    ContactComponent,
    AddEditContactComponent
  ],
  imports: [ 
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    AngularEditorModule,
    NgxPaginationModule,
    Ng2OrderModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 10000
    })
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }

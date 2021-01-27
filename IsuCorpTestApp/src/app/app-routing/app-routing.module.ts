import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {Routes, RouterModule} from '@angular/router';

import{ReservationComponent} from '../reservation/reservation.component';
import{AddEditReservationComponent} from '../reservation/add-edit-reservation/add-edit-reservation.component';
import{ContactTypeComponent} from '../contact-type/contact-type.component';
import{AddEditContactTypeComponent} from '../contact-type/add-edit-contact-type/add-edit-contact-type.component';
import{ContactComponent} from '../contact/contact.component';
import{AddEditContactComponent} from '../contact/add-edit-contact/add-edit-contact.component';

const routes: Routes = [
  {path: 'reservation', component: ReservationComponent},
  {path: 'addEditReservation/:id', component: AddEditReservationComponent},
  {path: 'contactType', component: ContactTypeComponent},
  {path: 'addEditContactType/:id', component: AddEditContactTypeComponent},
  {path: 'contact', component: ContactComponent},
  {path: 'addEditContact/:id', component: AddEditContactComponent}
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes),
    CommonModule
  ],
  exports: [
    RouterModule
  ]
})

export class AppRoutingModule { }

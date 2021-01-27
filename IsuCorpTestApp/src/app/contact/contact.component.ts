import { Component, OnInit } from '@angular/core';
import { ContactService } from '../shared/contact.service';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})

export class ContactComponent implements OnInit {
  contactId: string = 'contactId';
  page:number=1;

  constructor(public service: ContactService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteContact(id)
        .subscribe(
          res => {
            this.service.refreshList();
            this.toastr.success("Deleted successfully", 'Reservation');
          },
          err => { console.log(err) }
        )
    }
  }

  reserve: boolean = false;
  sort(contactId: string){
    this.contactId = contactId;
    this.reserve = !this.reserve;
  }
}

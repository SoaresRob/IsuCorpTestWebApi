import { Component, OnInit } from '@angular/core';
import { ContactType } from '../shared/contact-type.model';
import { ContactTypeService } from '../shared/contact-type.service';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-contact-type',
  templateUrl: './contact-type.component.html',
  styleUrls: ['./contact-type.component.css']
})
export class ContactTypeComponent implements OnInit {

  constructor(public service: ContactTypeService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }
  
  populateForm(selectedRecord: ContactType) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteContactType(id)
        .subscribe(
          res => {
            this.service.refreshList();
            this.toastr.success("Deleted successfully", 'Contact Type');
          },
          err => { console.log(err) }
        )
    }
  }
}

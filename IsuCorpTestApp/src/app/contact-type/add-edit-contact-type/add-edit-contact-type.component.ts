import { Component, OnInit } from '@angular/core';
import { ContactType } from 'src/app/shared/contact-type.model';
import { NgForm } from '@angular/forms';
import { ContactTypeService } from 'src/app/shared/contact-type.service';
import { ActivatedRoute } from '@angular/router';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-add-edit-contact-type',
  templateUrl: './add-edit-contact-type.component.html',
  styleUrls: ['./add-edit-contact-type.component.css']
})

export class AddEditContactTypeComponent implements OnInit {
  ContactTypeId: number=0;

  constructor(public service: ContactTypeService, private route: ActivatedRoute,
    private toastr:ToastrService) { 
    this.ContactTypeId = this.route.snapshot.params.id 
  }

  ngOnInit(): void {
    this.service.formData = new ContactType();

    if(this.ContactTypeId != 0)
      this.populateForm(this.ContactTypeId);
  }
  
  populateForm(id: number){
    this.service.selectItem(id).subscribe(
      (data: any)=>
      { 
        this.service.formData = Object.assign({},data)
      },
      err => { 
        this.toastr.error(err.error, 'Contact Type');
       }
      );
      
  }

  onSubmit(form: NgForm) {
    if (this.ContactTypeId == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postContactType().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success('Submitted successfully', 'Contact Type')
      },
      err => { 
        this.toastr.error(err.error, 'Contact Type');
       }
    );
  }

  updateRecord(form: NgForm) {
    this.service.putContactType().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success('Updated successfully', 'Contact Type')
      },
      err => { 
        this.toastr.error(err.error, 'Contact Type');
       }
    );
  }


  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new ContactType();
  }
}

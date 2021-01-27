import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Contact } from 'src/app/shared/contact.model';
import { ContactService } from 'src/app/shared/contact.service';
import { SharedService } from "src/app/shared.service";
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-add-edit-contact',
  templateUrl: './add-edit-contact.component.html',
  styleUrls: ['./add-edit-contact.component.css']
})
export class AddEditContactComponent implements OnInit {
  ContactId: number=0;
  ContactTypeList: any=[];

  constructor(public service: ContactService, private route: ActivatedRoute, 
    private shared: SharedService, private toastr:ToastrService) { 
    this.ContactId = this.route.snapshot.params.id 
  }

  ngOnInit(): void {
    this.loadContactTypeList();
    if(this.ContactId != 0)
      this.populateForm(this.ContactId);
  }
  
  populateForm(id: number){
    this.service.selectItemById(id).subscribe(
      (data: any)=>
      { 
        this.service.formData = Object.assign({},data)
      });
  }

  onSubmit(form: NgForm) {
    if (this.ContactId == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postContact().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success('Submitted successfully', 'Contact');
      },
      err => { console.log(err); }
    );
  }

  updateRecord(form: NgForm) {
    this.service.putContact().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success('Updated successfully', 'Contact');
      },
      err => { console.log(err); }
    );
  }


  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new Contact();
  }

  loadContactTypeList(){
    this.shared.getAllContactType().subscribe((data:any)=>{
      this.ContactTypeList = data;
    });
  }
}

import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from "src/app/shared.service";
import { ActivatedRoute } from "@angular/router";
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { ContactService } from 'src/app/shared/contact.service';
import {ToastrService} from 'ngx-toastr';


@Component({
  selector: 'app-add-edit-reservation',
  templateUrl: './add-edit-reservation.component.html',
  styleUrls: ['./add-edit-reservation.component.css']
})

export class AddEditReservationComponent implements OnInit {
  @Input() reservation: any;
  RevervationId: string="";
  ContactId: number=0;
  ContactName: string= "";
  PhoneNumber: string="";
  BirthDate: string="";
  ContactTypeId: string="";
  ReservationDetails: string="";

  ContactTypeList: any=[];

  constructor(private service: SharedService, private route: ActivatedRoute, 
    public contactService: ContactService, private toastr:ToastrService) {
    this.RevervationId = this.route.snapshot.params.id  
  }

  ngOnInit(): void {
    this.loadContactTypeList();
    if(this.RevervationId != "0")
      this.loadReservationDetails();
  }

  onBlur(){
    this.contactService.selectItemByName(this.contactService.formData.contactName).subscribe(
      (data: any)=>
      { 
        if(data.contactId != 0){
          this.contactService.formData = Object.assign({},data)
          this.ContactId = data.contactId;
        }
          
      },
      err => { 
        console.log(err);
      });
  }

  loadReservationDetails(){
    this.service.getReservation(this.RevervationId).subscribe((data:any)=>{
      this.RevervationId = data.revervationId;
      this.ContactId = data.contactId;
      this.ContactName =  data.contactName;
      this.PhoneNumber = data.phoneNumber;
      this.BirthDate = data.BirthDate;
      this.ContactTypeId = data.contactTypeId;
      this.ReservationDetails = data.reservationDetails;
    });
  }

  loadContactTypeList(){
    this.service.getAllContactType().subscribe((data:any)=>{
      this.ContactTypeList = data;
    });
  }

  sendReservation() {
    if (this.RevervationId == "0"){
      this.addReservation();
    }
      
    else
      this.updateReservation();  
  }

  addContact()
  {
    if(this.contactService.formData.contactId == 0)
      {
        this.contactService.selectItemByName(this.contactService.formData.contactName).subscribe(
          (data: any)=>
          {
            if(data.contactId == 0)
              {                
                this.contactService.postContact().subscribe(
                  (data: any) => { 
                    this.contactService.formData = Object.assign({},data)
                  },
                  err => { console.log(err); }
                  );
              }
          },
          err => { 
            console.log(err);
          });
      }    
  }

  addReservation(){
    if(this.contactService.formData.contactId == 0)
      {
        this.contactService.selectItemByName(this.contactService.formData.contactName).subscribe(
          (data: any)=>
          {
            if(data.contactId == 0)
              {                
                this.contactService.postContact().subscribe(
                  (data: any) => { 
                    this.contactService.formData = Object.assign({},data)

                    var val = {ReservationId:this.RevervationId,
                      ContactId: this.contactService.formData.contactId,
                      ContactName: this.contactService.formData.contactName,
                      PhoneNumber: this.contactService.formData.phoneNumber,
                      BirthDate: this.contactService.formData.birthDate,
                      ContactTypeId: this.contactService.formData.contactTypeId,
                      ReservationDetails: this.ReservationDetails};
                      
                      this.service.addReservation(val)
                        .subscribe(
                            res=>
                            {
                              this.toastr.success('Submitted successfully', 'Reservation');
                            },
                           err => { alert(err)}
                           );    
                  },
                  err => { console.log(err); }
                  );
              }
          },
          err => { 
            console.log(err);
          });
      }
      else
      {
        var val = {ReservationId:this.RevervationId,
          ContactId: this.contactService.formData.contactId,
          ContactName: this.contactService.formData.contactName,
          PhoneNumber: this.contactService.formData.phoneNumber,
          BirthDate: this.contactService.formData.birthDate,
          ContactTypeId: this.contactService.formData.contactTypeId,
          ReservationDetails: this.ReservationDetails};
          
          this.service.addReservation(val)
            .subscribe(
                res=>
                {
                  this.toastr.success('Submitted successfully', 'Reservation');
                },
               err => { alert(err)}
               );    
      }    
  }

  updateReservation(){
    var val = {ReservationId:this.RevervationId,
      ContactId: this.contactService.formData.contactId,
      ContactName: this.contactService.formData.contactName,
      PhoneNumber: this.contactService.formData.phoneNumber,
      BirthDate: this.contactService.formData.birthDate,
      ContactTypeId: this.contactService.formData.contactTypeId,
      ReservationDetails: this.ReservationDetails};

    this.service.updateReservation(val)
      .subscribe(
          res=>
          {
            this.toastr.success('Updated successfully', 'Contact');
          },
        err => { console.log(err);}
        );
  }

  config: AngularEditorConfig = {
    editable: true,
    spellcheck: true,
    height: '15rem',
    minHeight: '5rem',
    placeholder: 'Enter text here...',
    translate: 'no',
    defaultParagraphSeparator: 'p',
    defaultFontName: 'Arial',
    toolbarHiddenButtons: [
      ['bold']
      ],
    customClasses: [
      {
        name: "quote",
        class: "quote",
      },
      {
        name: 'redText',
        class: 'redText'
      },
      {
        name: "titleText",
        class: "titleText",
        tag: "h1",
      },
    ]
  };
}

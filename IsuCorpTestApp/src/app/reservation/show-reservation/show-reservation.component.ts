import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-show-reservation',
  templateUrl: './show-reservation.component.html',
  styleUrls: ['./show-reservation.component.css']
})
export class ShowReservationComponent implements OnInit {
  key: string = 'id';
  page:number=1;
  reverse: boolean = false;

  constructor(private service: SharedService, private toastr:ToastrService) { }

  ReservationList:any=[];
  reservation:any;

  ngOnInit(): void {
    this.refreshReservationList();
  }

  deleteClick(item: any){
    if(confirm('Are you sure?')){
      this.service.deleteReservation(item.revervationId).subscribe(data=>{
        this.toastr.success("Deleted successfully", 'Reservation');
        this.refreshReservationList();
      });
    }
  }

  addClick(){
    this.reservation={
      ReservationId:0,
      ContactName:""
    }
  }

  editClick(item: any){
    this.reservation = item;
  }

  refreshReservationList() {
    this.service.getReservationDTO().subscribe(data =>{
      console.log(data);
      this.ReservationList = data;
    });
  }

  sort(key: string){
    this.key = key;
    this.reverse = !this.reverse;
  }
}

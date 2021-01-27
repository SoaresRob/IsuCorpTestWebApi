import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

readonly APIUrl = "https://localhost:44352/api";

readonly PhotoUrl = "https://localhost:44352/Photos";

  constructor(private http:HttpClient) { }

  getReservationList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl +'/Reservations');
  }

  addReservation(val:any){
    return this.http.post(this.APIUrl + '/Reservations', val);
  }

  updateReservation(val:any){
    return this.http.put(this.APIUrl + '/Reservations/' + val.RevervationId, val);
  }

  deleteReservation(val:any){
    return this.http.delete(this.APIUrl + '/Reservations/' + val);
  }

  uploadPhoto(val:any){
    return this.http.post(this.APIUrl + '/Reservations/SaveFile', val);
  }

  getAllContactType():Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl + '/ContactTypes');
  }

  getReservation(val:any){
    return this.http.get(this.APIUrl + '/ReservationDTO/' + val);
  }

  getReservationDTO():Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl + '/ReservationDTO');
  }
  
}

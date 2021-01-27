import { Injectable } from '@angular/core';
import { ContactType } from './contact-type.model';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ContactTypeService {

  readonly APIUrl = "https://localhost:44352/api/ContactTypes";
  
  constructor(private http:HttpClient) { }

  formData:ContactType = new ContactType();
  list: ContactType[] = [];

  postContactType() {
    return this.http.post(this.APIUrl, this.formData);
  }

  putContactType() {
    return this.http.put(`${this.APIUrl}/${this.formData.contactTypeId}`, this.formData);
  }

  deleteContactType(id: number) {
    return this.http.delete(`${this.APIUrl}/${id}`);
  }

  refreshList() {
    this.http.get(this.APIUrl)
      .toPromise()
      .then(res =>this.list = res as ContactType[]);
  }

  selectItem(id: number) {
    return this.http.get(`${this.APIUrl}/${id}`);
  }
}

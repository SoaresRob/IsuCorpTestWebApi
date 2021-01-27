import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Contact } from './contact.model';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  readonly APIUrl = "https://localhost:44352/api/Contacts";
  readonly APIUrlDTO = "https://localhost:44352/api/ContactDTOes";
  
  constructor(private http:HttpClient) { }

  formData:Contact = new Contact();
  list: Contact[] = [];

  postContact() {
    return this.http.post(this.APIUrl, this.formData);
  }

  putContact() {
    return this.http.put(`${this.APIUrl}/${this.formData.contactTypeId}`, this.formData);
  }

  deleteContact(id: number) {
    return this.http.delete(`${this.APIUrl}/${id}`);
  }

  refreshList() {
    this.http.get(this.APIUrlDTO)
      .toPromise()
      .then(res =>this.list = res as Contact[]);
  }

  selectItemById(id: number) {
    return this.http.get(`${this.APIUrl}/${id}`);
  }
  selectItemByName(name: string) {
    return this.http.get(`${this.APIUrl}/${0},${name}`);
  }
}

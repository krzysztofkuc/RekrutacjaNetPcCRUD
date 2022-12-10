import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ContactCategoryModel } from '../model/contactCategoryModel';
import { ContactModel } from '../model/ContactModel';
import { ContactSubategoryModel } from '../model/contactSubcategoryModel';
import { HttpRequestsService } from './http-request.service';

@Injectable({
  providedIn: 'root'
})
export class ContactListService {

  constructor(private _http: HttpRequestsService) { }

  getList(): Observable<ContactModel[]> {

    return this._http.get("Contacts/GetAllContacts");
  }

  addContact(contact: ContactModel): Observable<ContactModel> {

    return this._http.post<ContactModel>("Contacts/AddContact", contact);
  }

  getAllContactRepos(): Observable<ContactCategoryModel[]> {

    return this._http.get("Contacts/GetAllContactCategories");
  }

  addSubcategory(subcategory: ContactSubategoryModel): Observable<ContactSubategoryModel> {

    return this._http.post<ContactSubategoryModel>("Contacts/AddSubcategory", subcategory);
  }

}

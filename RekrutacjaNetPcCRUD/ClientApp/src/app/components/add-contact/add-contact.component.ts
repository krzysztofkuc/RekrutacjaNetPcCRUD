import { Component, EventEmitter, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig } from 'primeng/dynamicdialog';
import { AddContactModel } from '../../model/AddContactModel';
import { ContactCategoryModel } from '../../model/contactCategoryModel';
import { ContactModel } from '../../model/ContactModel';
import { ContactListService } from '../../services/contact-list.service';
import { AddSubcategoryPopupComponent } from '../add-subcategory-popup/add-subcategory-popup.component';

@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrls: ['./add-contact.component.css']
})
export class AddContactComponent implements OnInit {

  form: FormGroup;
  contact: AddContactModel;
  public contactAdded = new EventEmitter<ContactModel>();

  constructor(private contactsSvc: ContactListService,
              private toastSvc: MessageService,
              private router: Router,
              public dialogService: DialogService,
              private config: DynamicDialogConfig,
              private fb: FormBuilder) { }

  ngOnInit(): void {
    this.contact = {
      Id: 0,
      Name: '',
      Surname:'' ,
      Email: '',
      Password: '',
      CategoryId: 0,
      Category: { Id: 0, Contacts: [], Name: '' },
      PhoneNo: '',
      DateOfBirth: new Date(),
      Categories : []
    }

    this.contactsSvc.getAllContactRepos().subscribe(res => {
      this.contact.Categories = res;
    },
    (error) => {
        console.log("Nie udało się pobrać kategorii", error);
    });

    this.form = this.fb.group({
      name: ['', Validators.required],
      surname: ['', Validators.required],
      password: ['', [Validators.required, Validators.pattern('((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,30})')]],
      email: ['', [Validators.email, Validators.required]],
      category: ['', Validators.required],
      phoneNo: [''],
      dateOfBirth: ['']
    });
  }

  categoryChanged() {

    this.contact.CategoryId = this.contact.Category.Id;
    if (this.contact.Category.Name == "inny") {
      this.showDialogAddSubcategory();
    }
  }

  showDialogAddSubcategory() {
    const ref = this.dialogService.open(AddSubcategoryPopupComponent, {
      data: {
        parentCategory: this.contact.Category
      },
      header: 'Dodaj podkategorię',
      width: '70%'
    });
  }

  submit() {
    this.contactsSvc.addContact(this.contact).subscribe();
  }

  get formCtrls() {
    return this.form.controls;
  }
}

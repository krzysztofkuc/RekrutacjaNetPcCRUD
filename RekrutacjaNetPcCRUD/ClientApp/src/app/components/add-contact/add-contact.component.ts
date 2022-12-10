import { Component, EventEmitter, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { AddContactModel } from '../../model/AddContactModel';
import { ContactModel } from '../../model/ContactModel';
import { ContactListService } from '../../services/contact-list.service';

@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrls: ['./add-contact.component.css']
})
export class AddContactComponent implements OnInit {

  form: FormGroup;
  contact: AddContactModel;
  selectedCategory: string;
  public contactAdded = new EventEmitter<ContactModel>();

  constructor(private contactsSvc: ContactListService,
              private toastSvc: MessageService,
              private router: Router,
              private fb: FormBuilder  ) { }

  ngOnInit(): void {
    this.contact = {
      Id: 0,
      Name: '',
      Surname:'' ,
      Email: '',
      Password:'' ,
      Category: '',
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

  submit() {
    //contact = {};

    //this.contactsSvc.addContact(contact).subscribe(res => {
    //  this.contactAdded.emit(res);
    //  this.toastSvc.add({ severity: 'success', summary: 'Success', detail: 'Dodano kontakt' });
    //  this.router.navigate(['/contactList']);
    //},
    //  (error) => {
    //    this.toastSvc.add({ severity: 'error', summary: 'Error', detail: 'Nie udao się dodać kontaktu' });
    //  }
    //);
  }

  get formCtrls() {
    return this.form.controls;
  }



}

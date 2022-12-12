import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { DynamicDialogConfig } from 'primeng/dynamicdialog';
import { ContactCategoryModel } from '../../model/contactCategoryModel';
import { ContactSubategoryModel } from '../../model/contactSubcategoryModel';
import { ContactListService } from '../../services/contact-list.service';

@Component({
  selector: 'app-add-subcategory-popup',
  templateUrl: './add-subcategory-popup.component.html',
  styleUrls: ['./add-subcategory-popup.component.css']
})
export class AddSubcategoryPopupComponent implements OnInit {
  form: FormGroup;
  category: ContactSubategoryModel;
  parentCategory: ContactCategoryModel

  constructor(private fb: FormBuilder,
              private contactListSvc: ContactListService,
              private toastSvc: MessageService,
              private  dialogConfig: DynamicDialogConfig) { }

  ngOnInit(): void {
    this.parentCategory = this.dialogConfig.data.parentCategory as ContactCategoryModel;

    //init interface
    this.category = { Id: 0, Name: '', CategoryId: this.parentCategory.Id, Category: this.parentCategory}

    this.form = this.fb.group({
      name: ['', Validators.required],
    });
  }

  submit(subcateogry: ContactSubategoryModel) {
    this.contactListSvc.addSubcategory(subcateogry).subscribe(res => {
      this.toastSvc.add({ severity: 'success', summary: 'Success', detail: 'Dodano' });
    },
    (error) => {
      this.toastSvc.add({ severity: 'error', summary: 'Error', detail: 'Nie dodano' });
    });
  }

  get formCtrls() {
    return this.form.controls;
  }

}

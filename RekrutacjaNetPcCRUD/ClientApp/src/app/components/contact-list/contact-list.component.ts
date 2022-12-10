import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ContactModel } from '../../model/ContactModel';
import { ContactListService } from '../../services/contact-list.service';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent implements OnInit {
  contacts: ContactModel[];

  constructor(private contactsSvc: ContactListService, private router: Router) { }

  ngOnInit(): void {
    this.contactsSvc.getList().subscribe(res => {
      this.contacts = res;
    });
  }

  navigateToAdd() {
    this.router.navigate(['/addContact']);
  }

}

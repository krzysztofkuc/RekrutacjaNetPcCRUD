import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserModel } from '../../model/UserModel';

import { Component, OnInit } from '@angular/core';
import { AuthorizationService } from '../../services/authorization.service';
//import { UserLogin } from 'src/app/model/userLogin';
//import { AuthService } from 'src/app/services/auth.service';
/*import { ToastrService, Toast } from 'ngx-toastr';*/
/*import { FormGroup, FormBuilder, Validators } from '@angular/forms';*/


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginModel: UserModel;
  form: FormGroup;

  constructor(private authSvc: AuthorizationService, private fb: FormBuilder) { }

  ngOnInit(): void {

    this.form = this.fb.group({
      email: ['', Validators.email],
      password: ['', Validators.required]
    });
  }

  login() {

    let user: UserModel = {
      Id : 0,
      Email : this.form.get('email')?.value,
      Password : this.form.get('password')?.value,
      Role: '',
      Token: ''
    }

    this.authSvc.login(user).subscribe(res => {
      localStorage.setItem('token', res.Token);
    });
  }

}

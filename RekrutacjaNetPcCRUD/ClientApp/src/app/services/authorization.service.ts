import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserModel } from '../model/UserModel';
import { HttpRequestsService } from './http-request.service';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {

  constructor(private _http: HttpRequestsService) { }

  login(user: UserModel): Observable<UserModel> {

    return this._http.authorize<UserModel>(user);
  }

}



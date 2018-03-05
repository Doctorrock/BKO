import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { BehaviorSubject } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

import {BaseService} from './base.service';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class UserService extends BaseService {

  private _authNavStatusSource = new BehaviorSubject<boolean>(false);
  authNavStatus$ = this._authNavStatusSource.asObservable();

  private loggedIn = false;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    super();
    this.loggedIn = !!localStorage.getItem('auth_token');
    this._authNavStatusSource.next(this.loggedIn);
  }

  login(userName, password) {
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');

    return this.http
      .post<string>(
      this.baseUrl + 'api/login',
        {userName,password }
    )
    //TODO: .map(r => JSON.parse(r, this.reviver)) maybe?
      .map(res => {
        console.log(res);
        localStorage.setItem('auth_token', res);
        this.loggedIn = true;
        this._authNavStatusSource.next(true);
        return true;
      });
  }


  isLoggedIn() {
    return this.loggedIn;
  }
}

interface Response {
  auth_token: string;
  id: string;
  expires_in: string;
}

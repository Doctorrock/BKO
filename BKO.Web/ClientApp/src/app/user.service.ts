import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class UserService {
  private loggedIn = false;
  private _authNavStatusSource;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  login(userName, password) {
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');

    return this.http
      .post(
      this.baseUrl + 'api/login',
        {userName,password }
    ).subscribe(res => {
      localStorage.setItem('auth_token', res["auth_token"]);
        this.loggedIn = true;
        this._authNavStatusSource.next(true);
        return true;
      });
  }

  isLoggedIn() {
    return this.loggedIn;
  }



}

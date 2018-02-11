import { Component, OnInit } from '@angular/core';
import { UserService } from '../../user.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})

export class LoginFormComponent implements OnInit {


  brandNew: boolean;
  errors: string;
  isRequesting: boolean;
  submitted: boolean = false;

  constructor(private userService: UserService) { }

  ngOnInit() {

  }

  ngOnDestroy() {
  }

  login({ value}: { value}) {
    this.submitted = true;
    this.isRequesting = true;
    this.errors = '';
    this.userService.login(value.email, value.password);
  }

}

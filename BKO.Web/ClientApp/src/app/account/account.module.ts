import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegistrationFormComponent } from './registration-form/registration-form.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { UserService } from '../user.service';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [RegistrationFormComponent, LoginFormComponent],
  providers : [UserService]
})
export class AccountModule { }

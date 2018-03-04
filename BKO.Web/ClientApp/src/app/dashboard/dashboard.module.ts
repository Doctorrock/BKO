import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HiddenComponent } from './hidden/hidden.component'
import { routing } from './dashboard.routing';


import { AuthGuard } from '../auth.guard';

@NgModule({
  imports: [
    CommonModule,
    routing
  ],
  declarations: [HiddenComponent],
  providers: [AuthGuard]
})
export class DashboardModule { }

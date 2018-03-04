
import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';

import { HiddenComponent } from './hidden/hidden.component';

import { AuthGuard } from '../auth.guard';

export const routing: ModuleWithProviders = RouterModule.forChild([
  {
    path: 'dashboard',
    component: HiddenComponent, canActivate: [AuthGuard],

    children: [
      { path: '', component: HiddenComponent }
    ]
  }
]);

// src/app/authentication/authentication.module.ts

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

// Import the Angular Material NgModules (not the component classes)
import { MatCardModule }             from '@angular/material/card';
import { MatFormFieldModule }        from '@angular/material/form-field';
import { MatInputModule }            from '@angular/material/input';
import { MatIconModule }             from '@angular/material/icon';
import { MatButtonModule }           from '@angular/material/button';
import { MatProgressSpinnerModule }  from '@angular/material/progress-spinner';

import { LoginPage } from './login-page/login-page';

@NgModule({
  declarations: [
    LoginPage
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,

    // Angular Material modules:
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    MatProgressSpinnerModule,
  ]
})
export class AuthenticationModule { }

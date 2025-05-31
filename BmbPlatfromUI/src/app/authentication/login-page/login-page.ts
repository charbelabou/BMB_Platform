import { Component } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {AuthService} from '../services/auth-service';

@Component({
  selector: 'app-login-page',
  standalone: false,
  templateUrl: './login-page.html',
  styleUrl: './login-page.scss'
})
export class LoginPage {
  loginForm: FormGroup;
  hidePassword = true;
  errorMessage: string | null = null;
  isLoading = false;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    // If already “logged in,” go straight to /orders
    if (this.authService.isLoggedIn()) {
      this.router.navigate(['/orders']);
    }
  }

  onSubmit(): void {
    if (this.loginForm.invalid) {
      return;
    }

    this.errorMessage = null;
    this.isLoading = true;

    const { username, password } = this.loginForm.value;
    this.authService.login(username, password).subscribe({
      next: (token) => {
        this.isLoading = false;
        // Navigate to order list (protected route) after successful login
        this.router.navigate(['/orders']);
      },
      error: (err) => {
        this.isLoading = false;
        this.errorMessage = err.message || 'Login failed';
      },
    });
  }
}


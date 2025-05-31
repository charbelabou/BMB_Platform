import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of, throwError } from 'rxjs';
import { delay } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private readonly TOKEN_KEY = 'token';

  constructor(private router: Router) {}

  /**
   * Simulate a login call. If credentials match, store a mock JWT.
   * Otherwise, throw an error.
   */
  login(username: string, password: string): Observable<string> {
    // NOTE: in a real app, call HttpClient.post('/api/auth/login', { username, password })
    if (username === 'admin' && password === 'password') {
      //token should match jwtSettings in my API gateway but for now its just dummy token
      const mockToken = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.mock-payload.signature';
      localStorage.setItem(this.TOKEN_KEY, mockToken);
      return of(mockToken).pipe(delay(500)); // simulate network latency
    } else {
      return throwError(() => new Error('Invalid credentials')).pipe(delay(500));
    }
  }

  logout(): void {
    localStorage.removeItem(this.TOKEN_KEY);
    this.router.navigate(['/login']);
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem(this.TOKEN_KEY);
  }

  getToken(): string | null {
    return localStorage.getItem(this.TOKEN_KEY);
  }
}

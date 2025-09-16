import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MatCardModule, MatButtonModule],
  template: `
    <div class="login-container">
      <mat-card>
        <h2>City Management App</h2>
        <p>Sign in with your Auth0 account</p>
        <button mat-raised-button color="primary" (click)="auth.login()">Login</button>
      </mat-card>
    </div>
  `,
  styles: [`
    .login-container {
      height: 100vh;
      display: flex;
      justify-content: center;
      align-items: center;
      background: #f0f2f5;
    }
    mat-card {
      padding: 40px;
      text-align: center;
    }
  `]
})
export class LoginComponent {
  constructor(public auth: AuthService) {}
}

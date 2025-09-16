import { Injectable } from '@angular/core';
import { AuthService as Auth0Service, User } from '@auth0/auth0-angular';
import { SessionService } from './session.service';
import { Router } from '@angular/router';
import { firstValueFrom } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthService {
  constructor(
    private auth0: Auth0Service,
    private session: SessionService,
    private router: Router
  ) {}

  async handleLoginRedirect() {
    // Wait until Auth0 finishes the redirect callback (if coming back from login)
    const isAuthenticated = await firstValueFrom(this.auth0.isAuthenticated$);

    if (isAuthenticated) {
      const user = await firstValueFrom(this.auth0.user$);
      this.session.username = user?.name ?? 'Unknown';

      // Get access token
      const token = await firstValueFrom(
        this.auth0.getAccessTokenSilently()
      );
      this.session.accessToken = token;

      // Redirect to /app
      if (window.location.pathname === '/login') {
        this.router.navigate(['/app']);
      }
    }
  }

  getToken(){
    return this.auth0.getAccessTokenSilently();
  }

  login() {
    this.auth0.loginWithRedirect();
  }

  logout() {
    this.auth0.logout({ logoutParams: { returnTo: window.location.origin } });
    this.session.clear();
    this.router.navigate(['/login']);
  }
}

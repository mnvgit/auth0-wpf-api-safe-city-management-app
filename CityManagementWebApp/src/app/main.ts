import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { provideAuth0 } from '@auth0/auth0-angular';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app';
import { AuthInterceptor } from './auth.interceptor';
import { routes } from './app-routes';


bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes),
    provideHttpClient(withInterceptorsFromDi()),
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    provideAuth0({
      domain: 'dev-u4t0zsbb0y0fio4y.us.auth0.com',
      clientId: 'pIf7pZVZkAKKnpPeSbTiSZiSJzqVbwzm',
      authorizationParams: {
        redirect_uri: window.location.origin,
        audience: 'https://city-management-api/',
        scope: 'openid profile email read:tasks create:tasks read:projects create:projects update:projects update:tasks'
      }
    })
  ]
}).catch(err => console.error(err));
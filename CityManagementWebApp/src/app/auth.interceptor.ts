import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent
} from '@angular/common/http';
import { Observable, from } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { AuthService as MyAuthService } from './services/auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private auth: MyAuthService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return from(this.auth.getToken()).pipe(
      switchMap(token => {
        let authReq = req;

        // Prepend base API URL if relative
        if (!req.url.startsWith('http')) {
          authReq = authReq.clone({
            url: `https://localhost:44322${req.url}`
          });
        }

        if (token) {
          authReq = authReq.clone({
            setHeaders: { Authorization: `Bearer ${token}` }
          });
        }

        return next.handle(authReq);
      })
    );
  }
}

import { AuthManagerService } from 'src/app/auth/services/auth-manager.service';
import { TokenManagerService } from './../managers/token-manager.service';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { EMPTY, Observable, catchError, throwError } from 'rxjs';
import { Router } from '@angular/router';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(
    private tokenManagerService: TokenManagerService,
    private router: Router,
    private authManagerService: AuthManagerService
  ) { }

  public intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const token = this.tokenManagerService.getToken();

    console.log(token)
    if (token) {
      return next.handle(
        request.clone({
          setHeaders: {
            'Authorization': `Bearer ${token}`
          }
        })
      ).pipe(
        catchError(error => {
          if (error.status === 401) {
            this.authManagerService.logout().subscribe(res => {
              this.router.navigate(['auth', 'login'])
            });
          }

          return throwError(error);
        })
      )
    } else {
      this.router.navigate(['auth', 'login']);

      return EMPTY;
    }
  }
}

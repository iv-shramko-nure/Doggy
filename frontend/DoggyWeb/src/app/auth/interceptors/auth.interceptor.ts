import { TokenManagerService } from './../managers/token-manager.service';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(
    private tokenManagerService: TokenManagerService
  ) { }

  public intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const token = this.tokenManagerService.getToken();
    if (token) {
      request.headers.append('Authorization', <string>token);
    }

    return next.handle(request);
  }
}

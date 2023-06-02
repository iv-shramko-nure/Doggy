import { TokenManagerService } from './../managers/token-manager.service';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject, map, tap } from 'rxjs';
import { RegisterData } from 'src/app/auth/models';
import { AuthApiService } from 'src/app/auth/services/auth-api.service';

@Injectable({
  providedIn: 'root'
})
export class AuthManagerService {

  constructor(
    private authApiService: AuthApiService,
    private tokenManagerService: TokenManagerService
  ) { }

  private _isAuthenticated = new BehaviorSubject<boolean>(false);
  public isAuthenticated = this._isAuthenticated.asObservable();

  public login(email: string, password: string): Observable<boolean> {
    return this.authApiService
      .login(email, password)
      .pipe(
        tap(response => {
          if (response.isSuccess) {
            this.tokenManagerService.setToken(<string>response.data)
            this._isAuthenticated.next(true);
          }
        }),
        map(response => response.isSuccess)
      );
  }

  public register(data: RegisterData) {
    return this.authApiService
      .register(data)
      .pipe(
        map(response => response.isSuccess)
      );
  }

  public logout(): Observable<boolean> {
    return this.authApiService
      .logout()
      .pipe(
        tap(response => {
          if (response.isSuccess) {
            this.tokenManagerService.removeToken();
            this._isAuthenticated.next(false);
          }
        }),
        map(response => response.isSuccess)
      );
  }

  public isAuthencicated() {
    const token = this.tokenManagerService.getToken();
    return !!token;
  }
}

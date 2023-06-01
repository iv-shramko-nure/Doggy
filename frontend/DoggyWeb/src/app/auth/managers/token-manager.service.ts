import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TokenManagerService {

  constructor() { }

  public setToken(token: string) {
    localStorage.setItem('access-token', token);
  }

  public getToken() {
    return localStorage.getItem('access-token');
  }

  public removeToken() {
    localStorage.removeItem('access-token');
  }
}

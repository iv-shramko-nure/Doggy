import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { get } from 'http';
import { LoginData, RegisterData } from 'src/app/auth/models';
import { APIResponse } from 'src/app/shared/models';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthApiService {

  constructor(
    private http: HttpClient
  ) { }

  public login(email: string, password: string) {
    const requestPayload: LoginData = {
      email: email,
      password: password
    }
    const path = `${environment.apiUrl}auth/login`
    return this.http.post<APIResponse<string>>(path, requestPayload);
  }

  public register(data: RegisterData) {
    const path = `${environment.apiUrl}auth/register`;
    return this.http.post<APIResponse<string>>(path, data);
  }

  public logout() {
    const path = `${environment.apiUrl}auth/logout`;
    return this.http.get<APIResponse<string>>(path);
  }
}

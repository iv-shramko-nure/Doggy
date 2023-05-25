import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegisterData } from 'src/app/auth/models';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthApiService {

  constructor(
    private http: HttpClient
  ) { }

  public login(login: string, password: string) {
    const path = `${environment.apiUrl}/auth/login`
    return this.http.get<any>(path);
  }

  public register(data: RegisterData) {
    const path = `${environment.apiUrl}/auth/register`;
    return this.http.post(path, data);
  }
}

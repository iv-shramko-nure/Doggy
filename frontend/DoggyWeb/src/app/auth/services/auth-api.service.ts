import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
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
}

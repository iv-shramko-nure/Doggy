import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ShelterRegisterData } from 'src/app/auth/components/shelter-register/models';
import { APIResponse } from 'src/app/shared/models';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ShelterRegisterApiService {

  constructor(
    private http: HttpClient
  ) { }

  public registerShelter(data: ShelterRegisterData) {
    const path = `${environment.apiUrl}/shelters`;
    this.http.post<APIResponse<string>>(path, data);
  }
}

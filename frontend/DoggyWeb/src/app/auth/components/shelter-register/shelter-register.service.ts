import { ShelterLegalInfo } from './models';
import { Injectable } from '@angular/core';
import { ShelterDescription, ShelterMainInfo, ShelterRegisterData } from 'src/app/auth/components/shelter-register/models';
import { RegisterData } from 'src/app/auth/models';
import { AuthManagerService } from 'src/app/auth/services/auth-manager.service';

@Injectable({
  providedIn: 'root'
})
export class ShelterRegisterService {

  constructor(
    private authManagerService: AuthManagerService,
  ) { }

  private shelterRegisterData: ShelterRegisterData = {
    website: '',
    name: '',
    address: '',
    description: '',
    accountNumber: '',
    payPalEmail: ''
  }

  public setMainInfo(data: ShelterMainInfo, password: string) {
    this.shelterRegisterData.website = data.website;

    const registerData: RegisterData = {
      fullName: '',
      email: data.email,
      phoneNumber: data.phoneNumber,
      password: password
    }

    this.authManagerService.register(registerData).subscribe();
  }

  public setDescription(data: ShelterDescription) {
    this.shelterRegisterData.name = data.name;
    this.shelterRegisterData.address = data.address;
    this.shelterRegisterData.description = data.description;
  }

  public setLegalInfo(data: ShelterLegalInfo) {
    this.shelterRegisterData.accountNumber = data.accountNumber;
    this.shelterRegisterData.payPalEmail = data.payPalEmail;
  }
}

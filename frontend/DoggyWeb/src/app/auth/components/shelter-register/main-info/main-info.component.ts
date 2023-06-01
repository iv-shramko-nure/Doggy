import { AuthManagerService } from 'src/app/auth/services/auth-manager.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { confirmPasswordValidatorFn } from 'src/app/shared/helpers';
import { RegisterData } from 'src/app/auth/models';
import { ShelterMainInfo } from 'src/app/auth/components/shelter-register/models';
import { ShelterRegisterService } from 'src/app/auth/components/shelter-register/shelter-register.service';

@Component({
  selector: 'app-main-info',
  templateUrl: './main-info.component.html',
  styleUrls: ['./main-info.component.css']
})
export class MainInfoComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private shelterRegisterService: ShelterRegisterService
  ) { }

  public mainInfoForm!: FormGroup;

  public ngOnInit(): void {
    this.initForm();
  }

  public onSubmit() {
    const registerData: ShelterMainInfo = {
      email: this.mainInfoForm.controls['email'].value,
      phoneNumber: this.mainInfoForm.controls['phoneNumber'].value,
      website: this.mainInfoForm.controls['website'].value,
    }

    const password = this.mainInfoForm.controls['password'].value;

    this.shelterRegisterService.setMainInfo(registerData, password);
  }

  private initForm() {
    this.mainInfoForm = this.fb.group({
      email: [
        null,
        [Validators.required, Validators.pattern('^[0-9A-Za-z-\.]+@([0-9A-Za-z-]+\.)+[0-9A-Za-z-]+$')]
      ],
      phoneNumber: [
        null,
        [Validators.required]
      ],
      website: [
        null,
      ],
      password: [
        null,
        [Validators.required]
      ],
      confirmPassword: [
        null,
        [Validators.required, confirmPasswordValidatorFn]
      ]
    });
  }

}

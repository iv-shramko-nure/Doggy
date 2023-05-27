import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { confirmPasswordValidatorFn } from 'src/app/shared/helpers';

@Component({
  selector: 'app-account-security',
  templateUrl: './account-security.component.html',
  styleUrls: ['./account-security.component.css']
})
export class AccountSecurityComponent implements OnInit {

  constructor(
    private fb: FormBuilder
  ) { }

  public securityForm!: FormGroup;

  public ngOnInit(): void {
    this.initForm();
  }

  public changePassword() { }

  private initForm() {
    this.securityForm = this.fb.group({
      oldPassword: [
        null,
        Validators.required
      ],
      password: [
        null,
        Validators.required
      ],
      confirmPassword: [
        null,
        [Validators.required, confirmPasswordValidatorFn]
      ]
    });
  }
}

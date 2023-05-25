import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { confirmPasswordValidatorFn } from 'src/app/auth/components/shelter-register/helpers';

@Component({
  selector: 'app-main-info',
  templateUrl: './main-info.component.html',
  styleUrls: ['./main-info.component.css']
})
export class MainInfoComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
  ) { }

  public mainInfoForm!: FormGroup;

  public ngOnInit(): void {
    this.initForm();
  }

  public onSubmit() {
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

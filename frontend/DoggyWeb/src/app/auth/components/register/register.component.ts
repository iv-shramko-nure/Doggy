import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegisterData } from 'src/app/auth/models';
import { AuthApiService } from 'src/app/auth/services/auth-api.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private authApiService: AuthApiService
  ) { }

  public registerForm!: FormGroup;

  public ngOnInit(): void {
    this.initForm();
  }

  public onSubmit() {
    const registerData: RegisterData = {
      fullName: this.registerForm.get('fullName')?.value,
      email: this.registerForm.get('email')?.value,
      phoneNumber: this.registerForm.get('phoneNumber')?.value,
      password: this.registerForm.get('password')?.value
    }

    this.authApiService.register(registerData).subscribe();
  }

  private initForm() {
    this.registerForm = this.fb.group({
      fullName: [
        null,
        [Validators.required]
      ],
      email: [
        null,
        [Validators.required, Validators.pattern('^[0-9A-Za-z-\.]+@([0-9A-Za-z-]+\.)+[0-9A-Za-z-]+$')]
      ],
      phoneNumber: [
        null,
        [Validators.required]
      ],
      password: [
        null,
        [Validators.required]
      ]
    });
  }
}

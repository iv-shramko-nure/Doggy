import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterData } from 'src/app/auth/models';
import { AuthApiService } from 'src/app/auth/services/auth-api.service';
import { AuthManagerService } from 'src/app/auth/services/auth-manager.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private authManagerService: AuthManagerService,
    private router: Router
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

    this.authManagerService.register(registerData).subscribe(result => {
      if (result) {
        this.router.navigate(['auth/login/']);
      }
    });
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
      ],
      termsAndPolicies: [
        false,
        [Validators.requiredTrue]
      ]
    });
  }
}

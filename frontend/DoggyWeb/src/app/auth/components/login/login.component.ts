import { AuthApiService } from './../../services/auth-api.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private authApiService: AuthApiService
  ) { }

  public loginForm!: FormGroup;

  public ngOnInit(): void {
    this.initForm();
  }

  public onSubmit() {
    this.authApiService.login(
      this.loginForm.controls['login'].value,
      this.loginForm.controls['password'].value
    ).subscribe();
  }

  private initForm() {
    this.loginForm = this.fb.group({
      login: [
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

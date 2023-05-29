import { AuthApiService } from './../../services/auth-api.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthManagerService } from 'src/app/auth/services/auth-manager.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private authManagerService: AuthManagerService,
    private router: Router
  ) { }

  public loginForm!: FormGroup;

  public ngOnInit(): void {
    this.initForm();
  }

  public onSubmit() {
    this.authManagerService
      .login(
        this.loginForm.controls['email'].value,
        this.loginForm.controls['password'].value
      )
      .subscribe(result => {
        if (result) {
          this.router.navigateByUrl('/');
        }
      });
  }

  private initForm() {
    this.loginForm = this.fb.group({
      email: [
        null,
        [Validators.required, Validators.pattern('^[0-9A-Za-z-\.]+@([0-9A-Za-z-]+\.)+[0-9A-Za-z-]+$')]
      ],
      password: [
        null,
        [Validators.required]
      ]
    });
  }

}

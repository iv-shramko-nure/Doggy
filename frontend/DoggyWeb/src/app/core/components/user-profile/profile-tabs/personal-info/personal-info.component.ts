import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-personal-info',
  templateUrl: './personal-info.component.html',
  styleUrls: ['./personal-info.component.css']
})
export class PersonalInfoComponent implements OnInit {

  constructor(
    private fb: FormBuilder
  ) { }

  public fullName: string = 'Ivan Shramko'
  public email: string = 'ffff@gggg.com'

  public profileForm!: FormGroup;

  public ngOnInit(): void {
    this.initForm();
  }

  public updateProfile() { }

  private initForm() {
    this.profileForm = this.fb.group({
      fullName: [
        null,
        Validators.required
      ],
      phone: [
        null,
        Validators.required
      ],
      email: [
        null,
        Validators.required
      ],
      address: [
        null,
        Validators.required
      ]
    });
  }

}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-legal-info',
  templateUrl: './legal-info.component.html',
  styleUrls: ['./legal-info.component.css']
})
export class LegalInfoComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
  ) { }

  public legalInfoForm!: FormGroup;

  public ngOnInit(): void {
    this.initForm();
  }

  public onSubmit() {
  }

  private initForm() {
    this.legalInfoForm = this.fb.group({
      accountNumber: [
        null,
        [Validators.required]
      ],
      payPalEmail: [
        null,
        []
      ],
      termsAndPolicies: [
        false,
        [Validators.requiredTrue]
      ]
    });
  }

}

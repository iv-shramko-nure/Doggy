import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { shelterLegalInfoFileUploadText } from 'src/app/shared/components/file-upload/constant';
import { AllowedFileTypes, FileUploadComponentParams } from 'src/app/shared/components/file-upload/models';

@Component({
  selector: 'app-legal-info',
  templateUrl: './legal-info.component.html',
  styleUrls: ['./legal-info.component.css']
})
export class LegalInfoComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
  ) { }

  public legalInfoForm: FormGroup = this.fb.group({
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
    ],
    documentImage: [
      null,
      Validators.required
    ]
  });;

  public fileUploadParams: FileUploadComponentParams = {
    ...shelterLegalInfoFileUploadText,
    form: this.legalInfoForm,
    formControlName: 'documentImage',
    fileType: AllowedFileTypes.Any,
  }

  public ngOnInit(): void {
  }

  public onSubmit() {
  }
}

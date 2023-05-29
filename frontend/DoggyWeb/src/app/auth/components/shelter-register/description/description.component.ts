import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { shelterDescriptionFileUploadText } from 'src/app/shared/components/file-upload/constant';
import { AllowedFileTypes, FileUploadComponentParams } from 'src/app/shared/components/file-upload/models';

@Component({
  selector: 'app-description',
  templateUrl: './description.component.html',
  styleUrls: ['./description.component.css']
})
export class DescriptionComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
  ) { }

  public descriptionForm: FormGroup = this.fb.group({
    name: [
      null,
      [Validators.required]
    ],
    address: [
      null,
      [Validators.required]
    ],
    description: [
      null,
      [Validators.required]
    ],
    shelterImage: [
      null,
      Validators.required
    ],
  });;

  public fileUploadParams: FileUploadComponentParams = {
    ...shelterDescriptionFileUploadText,
    form: this.descriptionForm,
    formControlName: 'shelterImage',
    fileType: AllowedFileTypes.Images,
  }

  public ngOnInit(): void {
  }

  public onSubmit() {
  }
}

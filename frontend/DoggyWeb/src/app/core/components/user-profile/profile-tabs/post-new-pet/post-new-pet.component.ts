import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { postNewPetFileUploadText } from 'src/app/shared/components/file-upload/constant';
import { AllowedFileTypes, FileUploadComponentParams } from 'src/app/shared/components/file-upload/models';

@Component({
  selector: 'app-post-new-pet',
  templateUrl: './post-new-pet.component.html',
  styleUrls: ['./post-new-pet.component.css']
})
export class PostNewPetComponent implements OnInit {

  constructor(
    private fb: FormBuilder
  ) { }

  public postPetForm: FormGroup = this.fb.group({
    petName: [
      null,
      [Validators.required]
    ],
    description: [
      null,
      [Validators.required]
    ],
    petCategory: [
      null,
      [Validators.required]
    ],
    termsAndPolicies: [
      false,
      [Validators.requiredTrue, Validators.required]
    ],
    petImage: [
      null,
      Validators.required
    ]
  });

  public fileUploadParams: FileUploadComponentParams = {
    ...postNewPetFileUploadText,
    form: this.postPetForm,
    formControlName: 'petImage',
    fileType: AllowedFileTypes.Images
  }

  public ngOnInit(): void {
  }

  public onPostpet() {

  }
}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-post-new-pet',
  templateUrl: './post-new-pet.component.html',
  styleUrls: ['./post-new-pet.component.css']
})
export class PostNewPetComponent implements OnInit {

  constructor(
    private fb: FormBuilder
  ) { }

  public postPetForm!: FormGroup;

  public ngOnInit(): void {
    this.initForm();
  }

  public onPostpet() {

  }

  private initForm() {
    this.postPetForm = this.fb.group({
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
      ]
    });
  }

}

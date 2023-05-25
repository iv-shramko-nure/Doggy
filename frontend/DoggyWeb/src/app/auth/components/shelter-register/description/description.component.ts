import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-description',
  templateUrl: './description.component.html',
  styleUrls: ['./description.component.css']
})
export class DescriptionComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
  ) { }

  public descriptionForm!: FormGroup;

  public ngOnInit(): void {
    this.initForm();
  }

  public onSubmit() {
  }

  private initForm() {
    this.descriptionForm = this.fb.group({
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
    });
  }

}

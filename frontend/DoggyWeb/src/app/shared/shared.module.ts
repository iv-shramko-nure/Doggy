import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileUploadComponent } from 'src/app/shared/components/file-upload/file-upload.component';
import { RatingComponent } from 'src/app/shared/components/rating/rating.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    FileUploadComponent,
    RatingComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
  ],
  exports: [
    FileUploadComponent,
    RatingComponent,
  ]
})
export class SharedModule { }

import { FormGroup } from "@angular/forms";

export interface FileUploadComponentParams {
  mainText: string,
  footerText: string,
  form: FormGroup,
  formControlName: string,
  fileType: AllowedFileTypes
}

export enum AllowedFileTypes {
  Images = 'image/*',
}
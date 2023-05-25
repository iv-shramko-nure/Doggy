import { AbstractControl, ValidationErrors } from "@angular/forms";

export function confirmPasswordValidatorFn(control: AbstractControl): ValidationErrors | null {
  if (control) {
    const password = control.root.get('password');
    const confirmPassword = control.root.get('confirmPassword');

    return password?.value === confirmPassword?.value ? null : { error: 'passwords not match' }
  }

  return null;
}
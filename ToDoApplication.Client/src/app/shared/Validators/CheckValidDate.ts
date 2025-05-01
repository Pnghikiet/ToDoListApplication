import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function validDate(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
        const dateNow = new Date
        const result = dateNow > control.value

        return result ? {invalid: true} : null
    }
}
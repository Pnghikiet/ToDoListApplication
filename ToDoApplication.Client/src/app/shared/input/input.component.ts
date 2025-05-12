import { Component, Input, input } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrl: './input.component.css'
})
export class InputComponent {
  @Input() inputType?:string
  @Input() inputPlaceholder? :string
  @Input() control!: FormControl
  @Input() apiError? : string | null

}

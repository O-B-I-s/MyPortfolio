import { Component, forwardRef, Input } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-input',
  standalone: false,
  //imports: [],
  template: `
    <input
      [type]="type"
      [value]="value"
      [disabled]="disabled"
      [placeholder]="placeholder"
      (input)="onInputChange($event)"
      (blur)="onTouched()"
      class="flex h-10 w-full rounded-md border border-input bg-background px-3 py-2 text-sm ring-offset-background file:border-0 file:bg-transparent file:text-sm file:font-medium placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-ring focus-visible:ring-offset-2 disabled:cursor-not-allowed disabled:opacity-50"
    />
  `,
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputComponent),
      multi: true,
    },
  ],
  styleUrl: './input.component.css',
})
export class InputComponent implements ControlValueAccessor {
  @Input() type = 'text';
  @Input() placeholder = '';

  value: any = '';
  disabled = false;

  onChange: any = () => {};
  onTouched: any = () => {};

  writeValue(value: any): void {
    this.value = value;
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState(isDisabled: boolean): void {
    this.disabled = isDisabled;
  }

  onInputChange(event: any): void {
    const value = event.target.value;
    this.value = value;
    this.onChange(value);
  }
}

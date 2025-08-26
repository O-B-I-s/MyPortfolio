import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-label',
  standalone: false,
  //  imports: [],
  template: `
    <label
      [for]="htmlFor"
      class="text-sm font-medium leading-none peer-disabled:cursor-not-allowed peer-disabled:opacity-70"
    >
      <ng-content></ng-content>
    </label>
  `,
  styleUrl: './label.component.css',
})
export class LabelComponent {
  @Input() htmlFor?: string;
}

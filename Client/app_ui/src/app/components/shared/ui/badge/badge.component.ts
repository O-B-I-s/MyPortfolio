import { Component, HostBinding, Input } from '@angular/core';

@Component({
  selector: 'app-badge',
   standalone: false,
  //imports: [],
  template: '<ng-content></ng-content>',
  styleUrl: './badge.component.css',
})
export class BadgeComponent {
  @Input() variant: 'default' | 'secondary' | 'destructive' | 'outline' =
    'default';

  @HostBinding('class')
  get classes(): string {
    const baseClasses =
      'inline-flex items-center rounded-full border px-2.5 py-0.5 text-xs font-semibold transition-colors focus:outline-none focus:ring-2 focus:ring-ring focus:ring-offset-2';
    const variantClasses = {
      default:
        'border-transparent bg-primary text-primary-foreground hover:bg-primary/80',
      secondary:
        'border-transparent bg-secondary text-secondary-foreground hover:bg-secondary/80',
      destructive:
        'border-transparent bg-destructive text-destructive-foreground hover:bg-destructive/80',
      outline: 'text-foreground',
    };
    return `${baseClasses} ${
      variantClasses[this.variant] || variantClasses.default
    }`;
  }
}

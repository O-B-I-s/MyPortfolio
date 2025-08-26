import {
  Component,
  EventEmitter,
  HostBinding,
  Input,
  Output,
} from '@angular/core';

@Component({
  selector: 'app-button',
   standalone: false,
  //imports: [],
  template: '<ng-content></ng-content>',
  styleUrl: './button.component.css',
})
export class ButtonComponent {
  @Input() variant:
    | 'default'
    | 'destructive'
    | 'outline'
    | 'secondary'
    | 'ghost'
    | 'link' = 'default';
  @Input() size: 'default' | 'sm' | 'lg' | 'icon' = 'default';
  @Input() disabled = false;
  @Output() onClick = new EventEmitter<MouseEvent>();

  @HostBinding('class')
  get classes(): string {
    return `inline-flex items-center justify-center rounded-md text-sm font-medium transition-colors 
      focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-ring focus-visible:ring-offset-2 
      disabled:pointer-events-none disabled:opacity-50 
      ${this.getVariantClasses()} 
      ${this.getSizeClasses()}`;
  }

  @HostBinding('attr.disabled')
  get isDisabled(): boolean | null {
    return this.disabled ? true : null;
  }

  handleClick(event: MouseEvent): void {
    if (!this.disabled) {
      this.onClick.emit(event);
    }
  }

  private getVariantClasses(): string {
    const variants = {
      default: 'bg-primary text-primary-foreground hover:bg-primary/90',
      destructive:
        'bg-destructive text-destructive-foreground hover:bg-destructive/90',
      outline:
        'border border-input bg-background hover:bg-accent hover:text-accent-foreground',
      secondary: 'bg-secondary text-secondary-foreground hover:bg-secondary/80',
      ghost: 'hover:bg-accent hover:text-accent-foreground',
      link: 'text-primary underline-offset-4 hover:underline',
    };
    return variants[this.variant] || variants.default;
  }

  private getSizeClasses(): string {
    const sizes = {
      default: 'h-10 px-4 py-2',
      sm: 'h-9 rounded-md px-3',
      lg: 'h-11 rounded-md px-8',
      icon: 'h-10 w-10',
    };
    return sizes[this.size] || sizes.default;
  }
}

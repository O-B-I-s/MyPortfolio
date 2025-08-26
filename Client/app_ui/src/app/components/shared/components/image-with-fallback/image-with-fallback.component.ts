import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-image-with-fallback',
   standalone: false,
  //imports: [],
  template: `
    <img
      [src]="currentSrc"
      [alt]="alt"
      [class]="className"
      (error)="onError()"
    />
  `,
  styleUrl: './image-with-fallback.component.css',
})
export class ImageWithFallbackComponent {
  @Input() src = '';
  @Input() alt = '';
  @Input() class = '';

  currentSrc = '';
  fallbackSrc =
    'data:image/svg+xml,%3Csvg xmlns="http://www.w3.org/2000/svg" width="400" height="400"%3E%3Crect width="400" height="400" fill="%23cccccc"/%3E%3Ctext x="50%25" y="50%25" font-size="18" fill="%23999999" text-anchor="middle" dominant-baseline="middle"%3EImage not available%3C/text%3E%3C/svg%3E';

  ngOnInit(): void {
    this.currentSrc = this.src;
  }

  onError(): void {
    this.currentSrc = this.fallbackSrc;
  }

  get className(): string {
    return this.class;
  }
}

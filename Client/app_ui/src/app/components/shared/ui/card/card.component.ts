import { Component } from '@angular/core';

@Component({
  selector: 'app-card',
   standalone: false,
  template: '<ng-content></ng-content>',
  host: {
    class: 'rounded-lg border bg-card text-card-foreground shadow-sm',
  },
})
export class CardComponent {}

@Component({
  selector: 'app-card-header',
   standalone: false,
  template: '<ng-content></ng-content>',
  host: {
    class: 'flex flex-col space-y-1.5 p-6',
  },
})
export class CardHeaderComponent {}

@Component({
  selector: 'app-card-content',
  standalone: false,
  template: '<ng-content></ng-content>',
  host: {
    class: 'p-6 pt-0',
  },
})
export class CardContentComponent {}

@Component({
  selector: 'app-card-footer',
   standalone: false,
  template: '<ng-content></ng-content>',
  host: {
    class: 'flex items-center p-6 pt-0',
  },
})
export class CardFooterComponent {}

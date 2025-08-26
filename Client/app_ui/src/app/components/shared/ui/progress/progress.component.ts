import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-progress',
  standalone: false,
  //imports: [],
  templateUrl: './progress.component.html',
  styleUrl: './progress.component.css',
})
export class ProgressComponent {
  @Input() value = 0;
}

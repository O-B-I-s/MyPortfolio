import { Component } from '@angular/core';
import { ButtonComponent } from '../shared/ui/button/button.component';

@Component({
  selector: 'app-hero-section',
  standalone: false,
  //  imports: [ButtonComponent],
  templateUrl: './hero-section.component.html',
  styleUrl: './hero-section.component.css',
})
export class HeroSectionComponent {
  scrollToSection(sectionId: string): void {
    const element = document.getElementById(sectionId);
    if (element) {
      element.scrollIntoView({ behavior: 'smooth' });
    }
  }
}

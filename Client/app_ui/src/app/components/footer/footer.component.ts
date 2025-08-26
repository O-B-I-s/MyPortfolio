import { Component } from '@angular/core';
import { ButtonComponent } from '../shared/ui/button/button.component';

@Component({
  selector: 'app-footer',
  standalone: false,
  //imports: [ButtonComponent],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.css',
})
export class FooterComponent {
  currentYear = new Date().getFullYear();

  scrollToTop(): void {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }

  scrollToSection(sectionId: string): void {
    const element = document.getElementById(sectionId);
    if (element) {
      element.scrollIntoView({ behavior: 'smooth' });
    }
  }
}

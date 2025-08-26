import { Component } from '@angular/core';
import { ButtonComponent } from '../shared/ui/button/button.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-header',
  standalone: false,
  //imports: [ButtonComponent, CommonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
})
export class HeaderComponent {
  isMenuOpen = false;

  toggleMenu(): void {
    this.isMenuOpen = !this.isMenuOpen;
  }

  scrollToSection(sectionId: string): void {
    const element = document.getElementById(sectionId);
    if (element) {
      element.scrollIntoView({ behavior: 'smooth' });
    }
    this.isMenuOpen = false;
  }
}

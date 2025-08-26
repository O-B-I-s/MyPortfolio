import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './components/header/header.component';
//import { ComponentsModule } from './components/components.module';
import { FooterComponent } from './components/footer/footer.component';
import { ContactSectionComponent } from './components/contact-section/contact-section.component';
import { ExperienceSectionComponent } from './components/experience-section/experience-section.component';
import { ProjectsSectionComponent } from './components/projects-section/projects-section.component';
import { HeroSectionComponent } from './components/hero-section/hero-section.component';
import { AboutSectionComponent } from './components/about-section/about-section.component';
import { SkillsSectionComponent } from './components/skills-section/skills-section.component';

@Component({
  selector: 'app-root',
  //standalone: false,
  imports: [
    HeaderComponent,
    HeroSectionComponent,
    AboutSectionComponent,
    SkillsSectionComponent,
    ProjectsSectionComponent,
    ExperienceSectionComponent,
    ContactSectionComponent,
    FooterComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'app_ui';
}

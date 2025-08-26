import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from './shared/shared.module';

// Components
import { HeaderComponent } from './header/header.component';
import { HeroSectionComponent } from './hero-section/hero-section.component';
import { AboutSectionComponent } from './about-section/about-section.component';
import { SkillsSectionComponent } from './skills-section/skills-section.component';
import { ProjectsSectionComponent } from './projects-section/projects-section.component';
import { ExperienceSectionComponent } from './experience-section/experience-section.component';
import { ContactSectionComponent } from './contact-section/contact-section.component';
import { FooterComponent } from './footer/footer.component';

const COMPONENTS = [
  HeaderComponent,
  HeroSectionComponent,
  AboutSectionComponent,
  SkillsSectionComponent,
  ProjectsSectionComponent,
  ExperienceSectionComponent,
  ContactSectionComponent,
  FooterComponent,
];

@NgModule({
  declarations: [...COMPONENTS],
  imports: [CommonModule, ReactiveFormsModule, SharedModule],
  exports: [...COMPONENTS],
})
export class ComponentsModule {}

import { Component } from '@angular/core';
import { BadgeComponent } from '../shared/ui/badge/badge.component';
import {
  CardComponent,
  CardContentComponent,
} from '../shared/ui/card/card.component';
import { ProgressComponent } from '../shared/ui/progress/progress.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

interface Skill {
  name: string;
  level: number;
}

interface SkillCategory {
  title: string;
  skills: Skill[];
}

@Component({
  selector: 'app-skills-section',
  imports: [FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './skills-section.component.html',
  styleUrl: './skills-section.component.css',
})
export class SkillsSectionComponent {
  skillCategories: SkillCategory[] = [
    {
      title: 'Frontend Development',
      skills: [
        { name: 'React', level: 95 },
        { name: 'TypeScript', level: 90 },
        { name: 'Next.js', level: 85 },
        { name: 'Tailwind CSS', level: 92 },
      ],
    },
    {
      title: 'Backend Development',
      skills: [
        { name: 'Node.js', level: 88 },
        { name: 'Python', level: 82 },
        { name: 'PostgreSQL', level: 85 },
        { name: 'MongoDB', level: 80 },
      ],
    },
    {
      title: 'Design & Tools',
      skills: [
        { name: 'Figma', level: 90 },
        { name: 'Adobe Creative Suite', level: 85 },
        { name: 'Git', level: 95 },
        { name: 'Docker', level: 75 },
      ],
    },
  ];

  technologies: string[] = [
    'React',
    'TypeScript',
    'Next.js',
    'Node.js',
    'Python',
    'PostgreSQL',
    'MongoDB',
    'Tailwind CSS',
    'Figma',
    'Git',
    'Docker',
    'AWS',
    'GraphQL',
    'REST APIs',
    'Jest',
    'Cypress',
  ];
}

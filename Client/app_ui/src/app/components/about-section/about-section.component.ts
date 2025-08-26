import { Component } from '@angular/core';
import { BadgeComponent } from '../shared/ui/badge/badge.component';
import {
  CardContentComponent,
  CardComponent,
} from '../shared/ui/card/card.component';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
//import { CardModule } from "../shared/ui/card/card.module";

interface Stat {
  value: string;
  label: string;
}

@Component({
  selector: 'app-about-section',
  //imports: [CommonModule, SharedModule],
  templateUrl: './about-section.component.html',
  styleUrl: './about-section.component.css',
})
export class AboutSectionComponent {
  competencies: string[] = [
    'Problem Solving',
    'Team Leadership',
    'Project Management',
    'Client Communication',
    'Agile Methodology',
    'Code Review',
  ];

  stats: Stat[] = [
    { value: '50+', label: 'Projects Completed' },
    { value: '5+', label: 'Years Experience' },
    { value: '20+', label: 'Happy Clients' },
    { value: '15+', label: 'Technologies' },
  ];
}

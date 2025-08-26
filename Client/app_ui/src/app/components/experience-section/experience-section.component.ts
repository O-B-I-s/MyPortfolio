import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

interface Experience {
  company: string;
  position: string;
  duration: string;
  description: string;
  technologies: string[];
}

@Component({
  selector: 'app-experience-section',
  imports: [FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './experience-section.component.html',
  styleUrl: './experience-section.component.css',
})
export class ExperienceSectionComponent {
  experiences: Experience[] = [
    {
      company: 'Tech Solutions Inc.',
      position: 'Senior Full Stack Developer',
      duration: '2022 - Present',
      description:
        'Lead development of scalable web applications using React, Node.js, and cloud technologies. Mentor junior developers and collaborate with cross-functional teams to deliver high-quality solutions.',
      technologies: ['React', 'Node.js', 'TypeScript', 'AWS', 'PostgreSQL'],
    },
    {
      company: 'Digital Agency Co.',
      position: 'Frontend Developer',
      duration: '2020 - 2022',
      description:
        'Developed responsive web applications and landing pages for various clients. Implemented modern UI/UX designs and optimized application performance.',
      technologies: ['React', 'Vue.js', 'Sass', 'Webpack', 'Git'],
    },
    {
      company: 'Startup Ventures',
      position: 'Junior Developer',
      duration: '2019 - 2020',
      description:
        'Built and maintained web applications using modern JavaScript frameworks. Collaborated with designers to implement pixel-perfect designs and improved code quality through testing.',
      technologies: ['JavaScript', 'HTML5', 'CSS3', 'Bootstrap', 'jQuery'],
    },
  ];
}

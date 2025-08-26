import { Component } from '@angular/core';

interface Experience {
  title: string;
  company: string;
  location: string;
  duration: string;
  type: string;
  description: string[];
  technologies: string[];
}

interface Education {
  degree: string;
  school: string;
  location: string;
  duration: string;
  description: string;
}
@Component({
  selector: 'app-experience-section',
   standalone: false,
  //imports: [],
  templateUrl: './experience-section.component.html',
  styleUrl: './experience-section.component.css',
})
export class ExperienceSectionComponent {
  experiences: Experience[] = [
    {
      title: 'Senior Full Stack Developer',
      company: 'TechCorp Solutions',
      location: 'San Francisco, CA',
      duration: '2022 - Present',
      type: 'Full-time',
      description: [
        'Led development of microservices architecture serving 100K+ daily active users',
        'Mentored 5 junior developers and established coding standards and best practices',
        'Reduced application load time by 40% through performance optimization',
        'Collaborated with product and design teams to deliver feature-rich applications',
      ],
      technologies: [
        'React',
        'Node.js',
        'PostgreSQL',
        'AWS',
        'Docker',
        'Kubernetes',
      ],
    },
    {
      title: 'Frontend Developer',
      company: 'Digital Agency Pro',
      location: 'New York, NY',
      duration: '2020 - 2022',
      type: 'Full-time',
      description: [
        'Developed responsive web applications for 15+ client projects',
        'Implemented modern UI/UX designs with pixel-perfect accuracy',
        'Integrated third-party APIs and payment systems',
        'Maintained 98% client satisfaction rate through quality deliverables',
      ],
      technologies: [
        'React',
        'Vue.js',
        'SASS',
        'JavaScript',
        'REST APIs',
        'Git',
      ],
    },
    {
      title: 'Junior Web Developer',
      company: 'StartupHub Inc',
      location: 'Austin, TX',
      duration: '2019 - 2020',
      type: 'Full-time',
      description: [
        'Built and maintained company website and internal tools',
        'Collaborated with cross-functional teams in agile environment',
        'Participated in code reviews and sprint planning sessions',
        'Gained experience in full-stack development lifecycle',
      ],
      technologies: ['HTML', 'CSS', 'JavaScript', 'PHP', 'MySQL', 'Bootstrap'],
    },
    {
      title: 'Freelance Web Developer',
      company: 'Self-Employed',
      location: 'Remote',
      duration: '2018 - 2019',
      type: 'Freelance',
      description: [
        'Created custom websites for small businesses and entrepreneurs',
        'Managed complete project lifecycle from requirements to deployment',
        'Provided ongoing maintenance and support for client websites',
        'Built strong client relationships resulting in repeat business',
      ],
      technologies: [
        'WordPress',
        'JavaScript',
        'CSS',
        'HTML',
        'Adobe Creative Suite',
      ],
    },
  ];

  education: Education[] = [
    {
      degree: 'Bachelor of Science in Computer Science',
      school: 'University of Technology',
      location: 'California, USA',
      duration: '2015 - 2019',
      description:
        'Graduated Magna Cum Laude with focus on Software Engineering and Web Technologies',
    },
    {
      degree: 'AWS Solutions Architect Certification',
      school: 'Amazon Web Services',
      location: 'Online',
      duration: '2021',
      description:
        'Certified in designing and deploying scalable systems on AWS',
    },
  ];

  achievements: string[] = [
    'Led team that won "Best Innovation" award at TechCorp hackathon',
    'Speaker at React Conference 2023',
    'Open source contributor with 500+ GitHub stars',
    'Mentored 10+ developers through coding bootcamps',
  ];
}

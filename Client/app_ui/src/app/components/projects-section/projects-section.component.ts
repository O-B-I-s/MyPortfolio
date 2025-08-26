import { Component } from '@angular/core';

interface Project {
  title: string;
  description: string;
  image: string;
  technologies: string[];
  liveUrl: string;
  githubUrl: string;
  featured: boolean;
}

@Component({
  selector: 'app-projects-section',
   standalone: false,
  //imports: [],
  templateUrl: './projects-section.component.html',
  styleUrl: './projects-section.component.css',
})
export class ProjectsSectionComponent {
  projects: Project[] = [
    {
      title: 'E-Commerce Platform',
      description:
        'A full-stack e-commerce solution with payment integration, inventory management, and admin dashboard. Built with modern React and Node.js.',
      image:
        'https://images.unsplash.com/photo-1634084462412-b54873c0a56d?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&w=1080',
      technologies: [
        'React',
        'Node.js',
        'PostgreSQL',
        'Stripe',
        'Tailwind CSS',
      ],
      liveUrl: '#',
      githubUrl: '#',
      featured: true,
    },
    {
      title: 'Task Management App',
      description:
        'A collaborative project management tool with real-time updates, team chat, and advanced analytics dashboard.',
      image:
        'https://images.unsplash.com/photo-1597740985671-2a8a3b80502e?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&w=1080',
      technologies: [
        'Next.js',
        'TypeScript',
        'Prisma',
        'WebSocket',
        'Shadcn/ui',
      ],
      liveUrl: '#',
      githubUrl: '#',
      featured: true,
    },
    {
      title: 'Portfolio Website',
      description:
        'A responsive portfolio website with dark mode, smooth animations, and optimized performance.',
      image:
        'https://images.unsplash.com/photo-1718220216044-006f43e3a9b1?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&w=1080',
      technologies: ['React', 'Tailwind CSS', 'Framer Motion', 'Vite'],
      liveUrl: '#',
      githubUrl: '#',
      featured: false,
    },
    {
      title: 'Weather Dashboard',
      description:
        'A beautiful weather application with location-based forecasts, interactive maps, and weather alerts.',
      image:
        'https://images.unsplash.com/photo-1634084462412-b54873c0a56d?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&w=1080',
      technologies: ['Vue.js', 'Python', 'FastAPI', 'Chart.js'],
      liveUrl: '#',
      githubUrl: '#',
      featured: false,
    },
    {
      title: 'Social Media Analytics',
      description:
        'A comprehensive analytics platform for social media management with real-time data visualization.',
      image:
        'https://images.unsplash.com/photo-1597740985671-2a8a3b80502e?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&w=1080',
      technologies: ['React', 'D3.js', 'MongoDB', 'Express.js'],
      liveUrl: '#',
      githubUrl: '#',
      featured: false,
    },
    {
      title: 'Booking System',
      description:
        'A complete booking and reservation system for restaurants with calendar integration and payment processing.',
      image:
        'https://images.unsplash.com/photo-1718220216044-006f43e3a9b1?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&w=1080',
      technologies: ['Angular', 'NestJS', 'MySQL', 'Redis'],
      liveUrl: '#',
      githubUrl: '#',
      featured: false,
    },
  ];

  get featuredProjects(): Project[] {
    return this.projects.filter((project) => project.featured);
  }

  get otherProjects(): Project[] {
    return this.projects.filter((project) => !project.featured);
  }
}

import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ButtonComponent } from '../shared/ui/button/button.component';
interface ContactInfo {
  icon: string;
  label: string;
  value: string;
  href: string;
}

interface SocialLink {
  icon: string;
  label: string;
  href: string;
  username: string;
}
@Component({
  selector: 'app-contact-section',
  standalone: false,
  //imports: [ButtonComponent],
  templateUrl: './contact-section.component.html',
  styleUrl: './contact-section.component.css',
})
export class ContactSectionComponent implements OnInit {
  contactForm!: FormGroup;

  contactInfo: ContactInfo[] = [
    {
      icon: 'mail',
      label: 'Email',
      value: 'hello@Johnson',
      href: 'mailto:hello@johnson',
    },
    {
      icon: 'phone',
      label: 'Phone',
      value: '+1 (825) 454-0771',
      href: 'tel:+18254540771',
    },
    {
      icon: 'location',
      label: 'Location',
      value: 'Calgary Alberta, CA',
      href: '#',
    },
  ];

  socialLinks: SocialLink[] = [
    {
      icon: 'github',
      label: 'GitHub',
      href: 'https://github.com/O-B-I-s',
      username: '@O-B-I-s',
    },
    {
      icon: 'linkedin',
      label: 'LinkedIn',
      href: 'www.linkedin.com/in/johnson-o-3974382b5',
      username: 'Johnson O',
    },
    {
      icon: 'twitter',
      label: 'Twitter',
      href: 'https://twitter.com/null',
      username: '@null',
    },
  ];

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.initForm();
  }

  private initForm(): void {
    this.contactForm = this.fb.group({
      name: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      subject: ['', [Validators.required]],
      message: ['', [Validators.required]],
    });
  }

  onSubmit(): void {
    if (this.contactForm.valid) {
      console.log('Form submitted:', this.contactForm.value);
      // Handle form submission here
      this.contactForm.reset();
    }
  }
}

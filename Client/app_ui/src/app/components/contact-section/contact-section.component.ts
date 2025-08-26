import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  Validators,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { ButtonComponent } from '../shared/ui/button/button.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-contact-section',

  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './contact-section.component.html',
  styleUrl: './contact-section.component.css',
})
export class ContactSectionComponent {
  contactForm!: FormGroup;
  constructor(private fb: FormBuilder) {
    this.contactForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(2)]],
      email: ['', [Validators.required, Validators.email]],
      subject: ['', [Validators.required, Validators.minLength(5)]],
      message: ['', [Validators.required, Validators.minLength(10)]],
    });
  }

  onSubmit(): void {
    if (this.contactForm.valid) {
      console.log('Form submitted:', this.contactForm.value);
      // Handle form submission here
      alert("Thank you for your message! I'll get back to you soon.");
      this.contactForm.reset();
    } else {
      // Mark all fields as touched to show validation errors
      this.contactForm.markAllAsTouched();
    }
  }

  // Helper method to check if a field has an error and is touched
  hasError(fieldName: string, errorType?: string): boolean {
    const field = this.contactForm.get(fieldName);
    if (!field) return false;

    if (errorType) {
      return !!(field.hasError(errorType) && field.touched);
    }
    return !!(field.invalid && field.touched);
  }
}

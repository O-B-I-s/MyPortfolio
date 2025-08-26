import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

// Import Card Module
import { CardModule } from './ui/card/card.module';

// UI Components
import { ButtonComponent } from './ui/button/button.component';
import { BadgeComponent } from './ui/badge/badge.component';
import { ProgressComponent } from './ui/progress/progress.component';
import { InputComponent } from './ui/input/input.component';
import { TextareaComponent } from './ui/textarea/textarea.component';
import { LabelComponent } from './ui/label/label.component';
import { ImageWithFallbackComponent } from './components/image-with-fallback/image-with-fallback.component';

const UI_COMPONENTS = [
  ButtonComponent,
  BadgeComponent,
  ProgressComponent,
  InputComponent,
  TextareaComponent,
  LabelComponent,
  ImageWithFallbackComponent
];

@NgModule({
  declarations: [...UI_COMPONENTS],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CardModule
  ],
  exports: [
    ...UI_COMPONENTS,
    CardModule
  ]
})
export class SharedModule { }
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UpdateCategoryFormComponent } from './update-category-form/update-category-form.component';
import { ComponentsModule } from '../../components/components.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [UpdateCategoryFormComponent],
  imports: [CommonModule, ComponentsModule, FormsModule, ReactiveFormsModule],
  exports: [UpdateCategoryFormComponent],
})
export class UpdateCategoryContainersModule {}

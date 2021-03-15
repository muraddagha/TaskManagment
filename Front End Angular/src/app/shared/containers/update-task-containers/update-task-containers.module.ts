import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UpdateTaskFormComponent } from './update-task-form/update-task-form.component';
import { ComponentsModule } from '../../components/components.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [UpdateTaskFormComponent],
  imports: [CommonModule, ComponentsModule, FormsModule, ReactiveFormsModule],
  exports: [UpdateTaskFormComponent],
})
export class UpdateTaskContainersModule {}

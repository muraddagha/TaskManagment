import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskComponent } from './task/task.component';
import { CategoryComponent } from './category/category.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    CategoryComponent,
    TaskComponent,
    TaskComponent,
    CategoryComponent,
  ],
  imports: [CommonModule, FontAwesomeModule, RouterModule],
  exports: [CategoryComponent, TaskComponent],
})
export class ComponentsModule {}

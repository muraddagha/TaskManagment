import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LayoutModule } from 'src/app/shared/containers/layout/layout.module';
import { ListsContainerModule } from 'src/app/shared/containers/lists-container/lists-container.module';
import { CreateCategoryComponent } from './create-category/create-category.component';
import { CreateCategoryContainersModule } from 'src/app/shared/containers/create-category-containers/create-category-containers.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { UpdateTaskComponent } from './update-task/update-task.component';
import { UpdateCategoryComponent } from './update-category/update-category.component';
import { UpdateCategoryContainersModule } from 'src/app/shared/containers/update-category-containers/update-category-containers.module';
import { CreateTaskContainersModule } from 'src/app/shared/containers/create-task-containers/create-task-containers.module';
import { UpdateTaskContainersModule } from 'src/app/shared/containers/update-task-containers/update-task-containers.module';
import { CreateTaskComponent } from './create-task/create-task.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CreateCategoryComponent,
    UpdateTaskComponent,
    UpdateCategoryComponent,
    CreateTaskComponent,
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    LayoutModule,
    ListsContainerModule,
    CreateCategoryContainersModule,
    FontAwesomeModule,
    UpdateCategoryContainersModule,
    CreateTaskContainersModule,
    UpdateTaskContainersModule,
  ],
})
export class AppModule {}

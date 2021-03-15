import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LastListComponent } from './last-list/last-list.component';
import { ComponentsModule } from '../../components/components.module';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [LastListComponent],
  imports: [CommonModule, ComponentsModule, RouterModule, FontAwesomeModule],
  exports: [LastListComponent],
})
export class ListsContainerModule {}

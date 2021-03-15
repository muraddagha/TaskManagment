import { Component, OnInit } from '@angular/core';
import { ICategory } from 'src/app/shared/models/category.model';
import { ITasks } from 'src/app/shared/models/tasks.model';
import { ApiService } from 'src/app/shared/services/api.service';
import { faEdit } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-last-list',
  templateUrl: './last-list.component.html',
  styleUrls: ['./last-list.component.scss'],
})
export class LastListComponent implements OnInit {
  icon = faEdit;

  public categories: ICategory[] = [];
  public tasks: ITasks[] = [];
  constructor(private apiService: ApiService) {
    this.getCategries();
    this.getTasks();
  }

  ngOnInit(): void {}
  private getCategries(): void {
    this.apiService.getCategory().subscribe(
      (res) => {
        this.categories = res;
      },
      (err) => {
        if (err.status == 500) console.log(err);
      }
    );
  }
  private getTasks(): void {
    this.apiService.getTasks().subscribe(
      (res) => {
        this.tasks = res;
      },
      (err) => {
        if (err.status == 500) console.log(err);
      }
    );
  }
}

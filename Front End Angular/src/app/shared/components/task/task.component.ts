import { Component, Input, OnInit } from '@angular/core';
import { ITasks } from '../../models/tasks.model';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { ApiService } from '../../services/api.service';
import { faEdit } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.scss'],
})
export class TaskComponent implements OnInit {
  @Input() tasks: ITasks;
  icon = faTrash;
  edit = faEdit;

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {}
  public removeTask(id) {
    this.apiService.removeTasks(id).subscribe((res) => {
      console.log('result', res);
      alert('Kateqoriya Silindi');
    });
  }
}

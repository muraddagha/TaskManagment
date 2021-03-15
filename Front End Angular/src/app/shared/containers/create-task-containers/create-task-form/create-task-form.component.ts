import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ICategory } from 'src/app/shared/models/category.model';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-create-task-form',
  templateUrl: './create-task-form.component.html',
  styleUrls: ['./create-task-form.component.scss'],
})
export class CreateTaskFormComponent implements OnInit {
  public submitted: boolean = false;
  public createTaskForm: FormGroup;
  public categories: ICategory[] = [];
  @Input() category: ICategory;
  constructor(
    private apiService: ApiService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {
    this.generateForm();
    this.getCategries();
  }

  ngOnInit(): void {}
  get f() {
    return this.createTaskForm.controls;
  }
  public generateForm() {
    this.createTaskForm = this.formBuilder.group({
      node: ['', [Validators.required]],
      endDate: ['', [Validators.required]],
      categoryId: ['', Validators.required],
      isDone: ['true'],
    });
  }

  public createTask() {
    console.log(this.createTaskForm.value);
    this.submitted = true;
    if (this.createTaskForm.invalid) return;

    this.apiService.createTasks(this.createTaskForm.value).subscribe((res) => {
      console.log(res);
      alert('Task Yaradıldı');
      this.router.navigate(['/app']);
    });
  }

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
}

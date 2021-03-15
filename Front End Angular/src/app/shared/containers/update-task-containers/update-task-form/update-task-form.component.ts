import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ICategory } from 'src/app/shared/models/category.model';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-update-task-form',
  templateUrl: './update-task-form.component.html',
  styleUrls: ['./update-task-form.component.scss'],
})
export class UpdateTaskFormComponent implements OnInit {
  public submitted: boolean = false;
  public updateTaskForm: FormGroup;
  public categories: ICategory[] = [];
  @Input() category: ICategory;

  constructor(
    private apiService: ApiService,
    private formBuilder: FormBuilder,
    private activeRoute: ActivatedRoute,
    private router: Router
  ) {
    this.generateForm();
    this.getCategries();
    this.getTaskById();
  }

  ngOnInit(): void {}
  get f() {
    return this.updateTaskForm.controls;
  }

  public generateForm() {
    this.updateTaskForm = this.formBuilder.group({
      node: ['', [Validators.required]],
      endDate: ['', [Validators.required]],
      categoryId: ['', Validators.required],
      isDone: ['true'],
    });
  }

  public updateTask() {
    console.log(this.updateTaskForm.value);
    this.submitted = true;
    if (this.updateTaskForm.invalid) return;
    var id = this.activeRoute.snapshot.paramMap.get('id');
    this.apiService.updateTasks(id, this.updateTaskForm.value).subscribe(
      (res) => {
        console.log(res);
        alert('Task Yaradıldı');
        this.router.navigate(['/app']);
      },
      (er) => {
        console.log(er);
      }
    );
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
  private getTaskById() {
    var id = this.activeRoute.snapshot.paramMap.get('id');
    this.apiService.getTaskById(id).subscribe((res) => {
      this.updateTaskForm.patchValue({
        node: res['node'],
        categoryId: res['categoryId'],
        isDone: res['isDone'],
      });
    });
  }
}

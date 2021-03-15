import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/shared/services/api.service';
import { ActivatedRoute } from '@angular/router';
import { ICategory } from 'src/app/shared/models/category.model';

@Component({
  selector: 'app-update-category-form',
  templateUrl: './update-category-form.component.html',
  styleUrls: ['./update-category-form.component.scss'],
})
export class UpdateCategoryFormComponent implements OnInit {
  public updateCategoryForm: FormGroup;
  public submitted: boolean = false;

  constructor(
    private apiService: ApiService,
    private formBuilder: FormBuilder,
    private router: Router,
    private activeRoute: ActivatedRoute
  ) {
    this.getCategriesById();
    this.generateForm();
  }

  ngOnInit(): void {}

  get f() {
    return this.updateCategoryForm.controls;
  }
  public generateForm() {
    this.updateCategoryForm = this.formBuilder.group({
      name: ['', [Validators.required]],
    });
  }

  public updateCategory() {
    this.submitted = true;
    var id = this.activeRoute.snapshot.paramMap.get('id');
    this.apiService
      .updateCategory(id, this.updateCategoryForm.value)
      .subscribe((res) => {
        console.log(res);
        alert('Kateqoriya Yeniləndi');
        this.router.navigate(['/app']);
      });
  }

  private getCategriesById(): void {
    var id = this.activeRoute.snapshot.paramMap.get('id');
    this.apiService.getCategoryById(id).subscribe(
      (res) => {
        this.updateCategoryForm.patchValue({
          name: res['name'],
        });
      },
      (err) => {
        if (err.status == 500) console.log(err);
      }
    );
  }
}

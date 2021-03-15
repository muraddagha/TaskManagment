import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-category-form',
  templateUrl: './category-form.component.html',
  styleUrls: ['./category-form.component.scss'],
})
export class CategoryFormComponent implements OnInit {
  name: string;
  public createCategoryForm: FormGroup;
  public submitted: boolean = false;

  constructor(
    private apiService: ApiService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {
    this.generateForm();
  }

  ngOnInit(): void {}

  get f() {
    return this.createCategoryForm.controls;
  }
  private generateForm() {
    this.createCategoryForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(50)]],
    });
  }

  public createCategory() {
    this.submitted = true;
    if (this.createCategoryForm.invalid) return;
    this.apiService.createCategory(this.createCategoryForm.value).subscribe(
      (res) => {
        console.log(res);
        alert('Kateqoriya Yaradıldı');
        this.router.navigate(['/app']);
      },
      (err) => {
        if (err.status === 409) {
          this.createCategoryForm.get('name').setErrors({ conflict: true });
        }
      }
    );
  }
}

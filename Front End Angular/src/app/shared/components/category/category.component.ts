import { Component, Input, OnInit } from '@angular/core';
import { ICategory } from '../../models/category.model';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { faEdit } from '@fortawesome/free-solid-svg-icons';
import { ICategoryResponse } from '../../models/response/category-response.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss'],
})
export class CategoryComponent implements OnInit {
  icon = faTrash;
  edit = faEdit;
  @Input() category: ICategory;
  constructor(private apiService: ApiService) {}

  ngOnInit(): void {}

  public removeCategory(id) {
    this.apiService.removeCategory(id).subscribe((res) => {
      console.log('result', res);
      alert('Kateqoriya Silindi');
    });
  }
}

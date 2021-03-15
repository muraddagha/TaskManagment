import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ICategory } from '../models/category.model';
import { ITasks } from '../models/tasks.model';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  constructor(private http: HttpClient) {}

  public getCategory(): Observable<ICategory[]> {
    return this.http.get<ICategory[]>(environment.apiUrl + `/Categories`);
  }

  public createCategory(data) {
    return this.http.post(environment.apiUrl + `/Categories`, data);
  }

  public updateCategory(id, data) {
    return this.http.put(environment.apiUrl + `/Categories/${id}`, data);
  }

  public removeCategory(id) {
    return this.http.delete(environment.apiUrl + `/categories/${id}`);
  }

  public getCategoryById(id): Observable<ICategory[]> {
    return this.http.get<ICategory[]>(environment.apiUrl + `/categories/${id}`);
  }

  //Taskss

  public getTasks(): Observable<ITasks[]> {
    return this.http.get<ITasks[]>(environment.apiUrl + `/Tasks`);
  }

  public createTasks(data) {
    return this.http.post(environment.apiUrl + `/Tasks`, data);
  }

  public updateTasks(id, data) {
    return this.http.put(environment.apiUrl + `/Tasks/${id}`, data);
  }

  public removeTasks(id) {
    return this.http.delete(environment.apiUrl + `/Tasks/${id}`);
  }
  public getTaskById(id): Observable<ICategory[]> {
    return this.http.get<ICategory[]>(environment.apiUrl + `/Tasks/${id}`);
  }

  // public CreateCategory() {
  //   return this.http.post(environment.apiUrl + '/categories', name);
  // }
}

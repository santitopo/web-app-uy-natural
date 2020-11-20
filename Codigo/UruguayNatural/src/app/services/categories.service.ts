import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Category } from 'src/Models/Category';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  
  uri = `${environment.baseUrl}/categories`;
  constructor(private http: HttpClient) {}

  getCategories(): Observable<Category> {
    return this.http.get<Category>(this.uri);
  }

}

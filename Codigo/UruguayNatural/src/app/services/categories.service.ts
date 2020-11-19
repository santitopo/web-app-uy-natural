import { Injectable } from '@angular/core';
import { Category } from 'src/Models/Category';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  categories: Category[] = new Array();
  constructor() {
    this.categories.push(
      new Category(
        1,
        'Aventura',
        null
      )
    );
    this.categories.push(
      new Category(
        1,
        'Balneario',
        null
      )
    );
    this.categories.push(
      new Category(
        1,
        'Campo',
        null
      )
    );
    this.categories.push(
      new Category(
        1,
        'Playa',
        null
      )
    );
    this.categories.push(
      new Category(
        1,
        'Colonial',
        null
      )
    );

   }

   getCategories(): Category[] {
    return this.categories;
  }
}

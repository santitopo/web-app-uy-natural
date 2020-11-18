import { Component, OnInit } from '@angular/core';
import { Category } from 'src/Models/Category';
import { Region } from 'src/Models/Region';
import { CategoriesService } from '../services/categories.service';
import { RegionsService } from '../services/regions.service';

@Component({
  selector: 'app-nav-regions',
  templateUrl: './nav-regions.component.html',
  styleUrls: ['./nav-regions.component.css']
})
export class NavRegionsComponent implements OnInit {
  regions: Region[];
  categories: Category[];
  Arr = Array;
  constructor(private regionsService: RegionsService, private categoriesService:CategoriesService)
    { this.regions = new Array();
      this.categories = new Array();}

   ngOnInit(): void {
    this.regions = this.regionsService.getRegions();
    this.categories = this.categoriesService.getCategories();
  }
}


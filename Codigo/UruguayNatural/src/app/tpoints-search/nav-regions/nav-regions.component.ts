import { Component, OnInit } from '@angular/core';
import { CategoriesService } from 'src/app/services/categories.service';
import { RegionsService } from 'src/app/services/regions.service';
import { Category } from 'src/Models/Category';
import { Region } from 'src/Models/Region';

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


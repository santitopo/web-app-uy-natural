import { HttpParams } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { CategoriesService } from 'src/app/services/categories.service';
import { DataService } from 'src/app/services/data.service';
import { RegionsService } from 'src/app/services/regions.service';
import { TPointsService } from 'src/app/services/tpoints.service';
import { Category } from 'src/Models/Category';
import { Region } from 'src/Models/Region';
import { TPoint } from 'src/Models/TPoint';

@Component({
  selector: 'app-nav-regions',
  templateUrl: './nav-regions.component.html',
  styleUrls: ['./nav-regions.component.css']
})
export class NavRegionsComponent implements OnInit {
  regions;
  categories;
  tpoints;
  params;
  selectedRegion: Region;
  selectedCatsId: number[];

  constructor(private regionsService: RegionsService, private categoriesService: CategoriesService, 
    private tpointsService: TPointsService, private dataService: DataService,  private router: Router) {
  }

  ngOnInit(): void {
    this.regionsService.getRegions().subscribe(
      res => {
        this.regions = res;
      },
      err => {
        alert('Ups algo salió mal...');
        console.log(err);
      });

    this.categoriesService.getCategories().subscribe(
      res => {
        this.categories = res;
      },
      err => {
        alert('Ups algo salió mal...');
        console.log(err);
      });
  }

  searchTPoints(): void{

    this.params = new HttpParams()
    .set('regionId', this.selectedRegion.id.toString())

    this.selectedCatsId.forEach(id => {
      this.params =this.params.append('categories', id);
    });
    
    this.tpointsService.getTPointsByRegionCat(this.params).subscribe(
      res => {
        this.tpoints = res;
      },
      err => {
        alert('Ups algo salió mal...');
        console.log(err);
      });
  }

  selectRegion(region : Region){
    this.selectedRegion = region;
  }

  goToLodgings(tpoint:TPoint){
    this.dataService.changeMessage(tpoint);
    this.router.navigate(['/lodgingsearch']);
  }
}


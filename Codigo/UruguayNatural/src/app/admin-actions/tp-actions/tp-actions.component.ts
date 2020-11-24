import { Variable } from '@angular/compiler/src/render3/r3_ast';
import { Component, OnInit } from '@angular/core';
import { CategoriesService } from 'src/app/services/categories.service';
import { RegionsService } from 'src/app/services/regions.service';
import { TPointsService } from 'src/app/services/tpoints.service';
import { Category } from 'src/Models/Category';
import { Region } from 'src/Models/Region';
import { TouristicPointInsert } from 'src/Models/TouristicPointInsert';

@Component({
  selector: 'app-tp-actions',
  templateUrl: './tp-actions.component.html',
  styleUrls: ['./tp-actions.component.css']
})
export class TpActionsComponent implements OnInit {
  regions;
  categories;
  tpoints;

  tpName: string;
  tpDescription: string;
  tpImage: string;
  selectedRegionId: number;
  selectedCatsId: number[];

  constructor(private regionsService: RegionsService, private categoriesService: CategoriesService, private tpointsService: TPointsService) {

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

      this.tpointsService.getTPoints().subscribe(
        res => {
          this.tpoints = res;
        },
        err => {
          alert('Ups algo salió mal...');
          console.log(err);
        });
  }

  addTPoint(): void {
    if(this.checkName()){
      const newTPoint = new TouristicPointInsert(this.tpName, this.tpDescription, this.tpImage,
        this.selectedRegionId, this.selectedCatsId);
        this.tpointsService.addTPoint(newTPoint).subscribe();
    }

  }

  checkName(): boolean{
    let ret = true;
    this.tpoints.forEach(object => {
      if(object.name == this.tpName){
        alert("repetido");
        ret = false;
      }
    });
    return ret;
  }

}

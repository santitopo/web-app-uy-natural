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
  regions: Region[];
  categories: Category[];

  tpName: string;
  tpDescription: string;
  image = "/tpoint.png";
  selectedRegionId: number;
  selectedCatsId: number[];

  constructor(private regionsService: RegionsService, private categoriesService: CategoriesService, private tpointService: TPointsService) { 
    this.regions = this.regionsService.getRegions();
    this.categories = this.categoriesService.getCategories();
  }

  ngOnInit(): void {
  }

  addTPoint(): void{
    const newTPoint = new TouristicPointInsert(this.tpName, this.tpDescription, this.image, 
    this.selectedRegionId , this.selectedCatsId);

    this.tpointService.addTPoint(newTPoint);
  }

}

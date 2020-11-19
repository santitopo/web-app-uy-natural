import { Component, OnInit } from '@angular/core';
import { Category } from 'src/Models/Category';
import { Region } from 'src/Models/Region';
import { TouristicPointInsert } from 'src/Models/TouristicPointInsert';

@Component({
  selector: 'app-tp-actions',
  templateUrl: './tp-actions.component.html',
  styleUrls: ['./tp-actions.component.css']
})
export class TpActionsComponent implements OnInit {
  tpName: string;
  tpDescription: string;
  image: string;
  regions: Region[];
  selectedRegion: number;
  categories: Category[];
  selectedCats: Category[];
  selectedCatsId: number[];
  
  constructor() { 
  }

  ngOnInit(): void {
  }

  addTPoint(): void{

    const newTPoint = new TouristicPointInsert(this.tpName, this.tpDescription, this.image, 
      this.selectedRegion , this.selectedCatsId);

  }

}

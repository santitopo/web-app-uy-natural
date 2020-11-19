import { Component, OnInit } from '@angular/core';
import { LodgingsService } from 'src/app/services/lodgings.service';
import { LodgingSearchResult } from 'src/Models/LodgingSearchResult';

@Component({
  selector: 'app-search-form',
  templateUrl: './search-form.component.html',
  styleUrls: ['./search-form.component.css']
})
export class SearchFormComponent implements OnInit {
  from: string;
  to: string;
  babyNum: number;
  childNum: number;
  adultNum: number;
  retiredNum: number;
  showingLodgings: boolean;

  lodgingSearchResults: LodgingSearchResult[];
  Arr = Array;
  constructor(private lodgingsService: LodgingsService) {
    this.lodgingSearchResults = new Array();
    this.showingLodgings = false;
   }

   ngOnInit(): void {
  }
  searchLodgings(): void{
    this.showingLodgings = true;
    this.lodgingSearchResults = this.lodgingsService.getResults();
  }

}

import { DatePipe } from '@angular/common';
import { HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataService } from 'src/app/services/data.service';
import { LodgingsService } from 'src/app/services/lodgings.service';
import { Lodging } from 'src/Models/Lodging';
import { LodgingSearchResult } from 'src/Models/LodgingSearchResult';
import { TPoint } from 'src/Models/TPoint';

@Component({
  selector: 'app-search-form',
  templateUrl: './search-form.component.html',
  styleUrls: ['./search-form.component.css']
})
export class SearchFormComponent implements OnInit {
  from: Date;
  to: Date;
  fromToString:string;
  toToString:string;

  babyNum: number;
  childNum: number;
  adultNum: number;
  retiredNum: number;
  showingLodgings: boolean;
  params;

  lodgingSearchResults;
  inputTpoint:any;
  
  starRating = 3;

  constructor(private lodgingsService: LodgingsService, private datePipe: DatePipe,
        private dataService: DataService) {
          // private currentRoute: ActivatedRoute
    this.showingLodgings = false;
    this.lodgingSearchResults = new Array();
   }

   ngOnInit(): void {
    this.dataService.currentMessage.subscribe(
      message => (this.inputTpoint= message)); //<= Always get current value!
    }
  searchLodgings(): void{
    this.fromToString = this.datePipe.transform(this.from,"ddMMyyyy");
    this.toToString = this.datePipe.transform(this.to,"ddMMyyyy");

    this.params = new HttpParams()
    .set('TPointId', this.inputTpoint.id.toString())
    .append('Checkin', this.fromToString)
    .append('Checkout', this.toToString)
    .append('RetiredNum', this.retiredNum.toString())
    .append('AdultsNum', this.adultNum.toString())
    .append('ChildsNum', this.childNum.toString())
    .append('BabiesNum', this.babyNum.toString());

    this.lodgingsService.getLodgingsByTP(this.params).subscribe(
      res => {
        this.lodgingSearchResults = res;
        this.showingLodgings = true;
      },
      err => {
        alert('Ups algo salió mal...');
        console.log(err);
      });

    //   let a = new LodgingSearchResult(120, new Lodging(undefined,"HotelRuta",undefined,"Bonito lugar","Casa de la esquina","59898788778",2,199,["\images\cabanas_quebradas.jpg"],3,true)) 
    //   let b = new LodgingSearchResult(120, new Lodging(undefined,"Hotel España",undefined,"Bonito lugar","Casa de la esquina","59898788778",2,199,["\images\cabanas_quebradas.jpg"],3,true)) 
      
    //   this.lodgingSearchResults.push(a);
    //   this.lodgingSearchResults.push(b);
      
    // this.showingLodgings = true;
  }

}

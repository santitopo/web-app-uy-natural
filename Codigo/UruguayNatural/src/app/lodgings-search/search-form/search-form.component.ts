import { DatePipe } from '@angular/common';
import { HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from 'src/app/services/data.service';
import { LodgingsService } from 'src/app/services/lodgings.service';
import { ReservationComunicationService } from 'src/app/services/reservation-comunication.service';
import { Lodging } from 'src/Models/Lodging';
import { LodgingSearch } from 'src/Models/LodgingSearch';
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
  searchModel:LodgingSearch;

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
        private dataService: DataService, private reservationDataService: ReservationComunicationService,
        private router: Router) {
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

    //Load the request for later comunication with confirmation page
    this.searchModel = new LodgingSearch(this.inputTpoint.id,
      this.fromToString,
      this.toToString,
      this.retiredNum,
      this.adultNum,
      this.childNum,
      this.babyNum);

    this.lodgingsService.getLodgingsByTP(this.params).subscribe(
      res => {
        this.lodgingSearchResults = res;
        this.showingLodgings = true;
      },
      err => {
        alert('Ups algo salió mal...');
        console.log(err);
      });
      }

    toReservationConfirmation(lodgingResult: LodgingSearchResult):void{
    this.reservationDataService.changeMessage(this.searchModel,lodgingResult);
    this.router.navigate(['/reservation']);
  }

}

import { DatePipe } from '@angular/common';
import { HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { LodgingsService } from 'src/app/services/lodgings.service';
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
  tpoint: TPoint;

  constructor(private lodgingsService: LodgingsService, private datePipe: DatePipe) {

    this.showingLodgings = false;
   }

   ngOnInit(): void {
  }
  searchLodgings(): void{
    this.fromToString = this.datePipe.transform(this.from,"ddMMyyyy");
    this.toToString = this.datePipe.transform(this.to,"ddMMyyyy");

    this.params = new HttpParams()
    .set('TPointId', this.tpoint.id.toString())
    .append('Checkin', this.fromToString)
    .append('Checkout', this.toToString)
    .append('RetiredNum', this.retiredNum.toString())
    .append('AdultsNum', this.adultNum.toString())
    .append('ChildsNum', this.childNum.toString())
    .append('BabiesNum', this.babyNum.toString());

    this.lodgingsService.getLodgingsByTP(this.params).subscribe(
      res => {
        this.lodgingSearchResults = res;
      },
      err => {
        alert('Ups algo salió mal...');
        console.log(err);
      });

    this.showingLodgings = true;

  }

}

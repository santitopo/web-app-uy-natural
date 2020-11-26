import { Component, OnInit } from '@angular/core';
import { ReservationComunicationService } from 'src/app/services/reservation-comunication.service';
import { ReservationsService } from 'src/app/services/reservations.service';
import { Bill } from 'src/Models/Bill';
import { LodgingSearch } from 'src/Models/LodgingSearch';
import { LodgingSearchResult } from 'src/Models/LodgingSearchResult';
import { Reservation } from 'src/Models/Reservation';
import { ReservationInsert } from 'src/Models/ReservationInsert';
import { Router } from '@angular/router';

@Component({
  selector: 'app-information-request',
  templateUrl: './information-request.component.html',
  styleUrls: ['./information-request.component.css']
})
export class InformationRequestComponent implements OnInit {

// Form Fields
  name;
  surname;
  email;
  notConfirmed:boolean;

  billModel: Bill;
  lodgingSearchResultModel : LodgingSearchResult;
  lodgingSearchModel: LodgingSearch;

  constructor(private reservationService:ReservationsService,
              private dataService: ReservationComunicationService,
              private router: Router)
     { this.notConfirmed=true;}

  ngOnInit(): void {
    this.dataService.currentMessage.subscribe(
      message => {
        this.lodgingSearchModel= message[0];
        this.lodgingSearchResultModel=message[1];
      }); //<= Always get current value!
    
  }

  confirmReservation(){
    let reservation = new ReservationInsert(
      this.lodgingSearchResultModel.lodging.id,
      this.lodgingSearchModel.checkin,
      this.lodgingSearchModel.checkout,
      this.lodgingSearchModel.retiredNum,
      this.lodgingSearchModel.adultsNum,
      this.lodgingSearchModel.childsNum,
      this.lodgingSearchModel.babiesNum,
      this.name,
      this.surname,
      this.email);
    this.reservationService.postReservation(reservation).subscribe(
      (res:Bill) => {
        this.billModel = res;
        this.notConfirmed = false;
      },
      err => {
        alert("Ups.. algo salio mal");
        console.log(err);
      }
    )
  }
  back(){
    this.router.navigate(['/menu']);
  }

}

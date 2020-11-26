import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-reservation-searchbar',
  templateUrl: './reservation-searchbar.component.html',
  styleUrls: ['./reservation-searchbar.component.css']
})
export class ReservationSearchbarComponent implements OnInit {
  reservationNumber:string;
  @Output()
  searchButtonClicked : EventEmitter<string> = new EventEmitter<string>();
  constructor() { }

  ngOnInit(): void {
  }

  search(){
      this.searchButtonClicked.emit(this.reservationNumber);
  }

}

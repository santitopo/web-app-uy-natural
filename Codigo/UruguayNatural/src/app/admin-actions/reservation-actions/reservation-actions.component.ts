import { Component, OnInit } from '@angular/core';
import { ReservationsService } from 'src/app/services/reservations.service';
import { Reservation } from 'src/Models/Reservation';
import { ReservationUpdate } from 'src/Models/ReservationUpdate';
import { State } from 'src/Models/State';

@Component({
  selector: 'app-reservation-actions',
  templateUrl: './reservation-actions.component.html',
  styleUrls: ['./reservation-actions.component.css']
})
export class ReservationActionsComponent implements OnInit {
  selectedReservation: Reservation;
  reservationState: string;
  actualState: string;
  selectedState: State;
  description: string;

  reservations;
  states;

  constructor(private reservationService: ReservationsService) {
  }

  ngOnInit(): void {

    this.reservationService.getReservations().subscribe(
      res => {
        this.reservations = res;
      },
      err => {
        alert('Ups algo salió mal...');
        console.log(err);
      });

    this.reservationService.getStates().subscribe(
      res => {
        this.states = res;
      },
      err => {
        alert('Ups algo salió mal...');
        console.log(err);
      });

  }

  select(selectedReservation: Reservation): void {

    this.states.forEach(value => {
      if (value.id == selectedReservation.id) {
        this.actualState = value.name;
      }
    });

  }

  modifyReservation(): void {
    const modifiedReservation = new ReservationUpdate(this.selectedReservation.id, this.selectedState.id, this.description);
    this.reservationService.updateReservation(modifiedReservation).subscribe(
      res => {
        this.selectedReservation = undefined;
        this.selectedState = undefined;
        this.description = "";
      }
    );

  }

}

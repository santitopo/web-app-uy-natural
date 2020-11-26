export class ReservationUpdate {
    reservationId: number;
    stateId: number;
    stateDescription: string;

constructor(ReservationId: number, StateId: number, StateDescription: string) {
    this.reservationId = ReservationId;
    this.stateId = StateId;
    this.stateDescription = StateDescription;
}

}


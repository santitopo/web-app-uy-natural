export class ReservationUpdate {
    ReservationId: number;
    StateId: number;
    StateDescription: string;

constructor(ReservationId: number, StateId: number, StateDescription: string) {
    this.ReservationId = ReservationId;
    this.StateId = StateId;
    this.StateDescription = StateDescription;
}

}


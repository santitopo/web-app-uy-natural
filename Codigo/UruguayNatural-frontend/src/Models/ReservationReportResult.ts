import { Lodging } from './Lodging';

export class ReservationReportResult {
    Lodging: Lodging;
    Reservations: number;

    constructor(Lodging: Lodging, Reservations: number) {
        this.Lodging = Lodging;
        this.Reservations = Reservations;
}

}

export class Review {
    Description: string;
    Score: number;
    ReservationCode: number;

    constructor(Description: string, Score: number, ReservationCode: number) {
        this.Description = Description;
        this.Score = Score;
        this.ReservationCode = ReservationCode;
    }

}

export class ReviewModel {
    Description: string;
    Score: number;
    ReservationCode: string;

    constructor(Description: string, Score: number, ReservationCode: string) {
        this.Description = Description;
        this.Score = Score;
        this.ReservationCode = ReservationCode;
    }

}

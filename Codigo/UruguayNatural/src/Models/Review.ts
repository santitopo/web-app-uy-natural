import { Lodging } from './Lodging';

export class Review {
    lodging: Lodging;
    id: number;
    description: string;
    score: number;
    client: string;

    constructor(Description: string, Score: number, ReservationCode: string,
        Id: number, lodging: Lodging) {
        this.description = Description;
        this.score = Score;
        this.client = "";
        this.id= Id;
        this.lodging = lodging;
    }
}
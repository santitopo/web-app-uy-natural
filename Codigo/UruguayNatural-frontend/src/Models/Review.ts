import { Client } from './Client';
import { Lodging } from './Lodging';

export class Review {
    lodging: Lodging;
    id: number;
    description: string;
    score: number;
    client: Client;

    constructor(Description: string, Score: number, ReservationCode: string,
        Id: number, Lodging: Lodging,  Client: Client) {
        this.description = Description;
        this.score = Score;
        this.client = Client;
        this.id= Id;
        this.lodging = Lodging;
    }
}
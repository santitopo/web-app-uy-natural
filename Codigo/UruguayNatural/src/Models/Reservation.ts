import { Client } from './Client';
import { Lodging } from './Lodging';
import { State } from './State';

export class Reservation {
    id: number;
    code: number;
    lodging: Lodging;
    client: Client;
    checkIn: string;
    checkOut: string;
    state: State;
    stateDescription: string;
    price: number;

    constructor(code: number, lodging: Lodging, client: Client, checkIn: string,
        checkOut: string, state: State, stateDescription: string, price: number) {
            this.code = code;
            this.lodging = lodging;
            this.client = client;
            this.checkIn = checkIn;
            this.checkOut = checkOut;
            this.state = state;
            this.stateDescription = stateDescription;
            this.price = price;
    }

}

export class Reservation {
    Code: number;
    LodgingId: number;
    ClientId: number;
    Checkin: string;
    Checkout: string;
    StateId: number;
    StateDescription: string;
    Price: number;

    constructor(Code: number, LodgingId: number, ClientId: number, Checkin: string,
        Checkout: string, StateId: number, StateDescription: string, Price: number) {
        this.Code = Code;
        this.LodgingId = LodgingId;
        this.ClientId = ClientId;
        this.Checkin = Checkin;
        this.Checkout = Checkout;
        this.StateId = StateId;
        this.StateDescription = StateDescription;
        this.Price = Price;
    }

}

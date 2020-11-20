export class ReservationInsert {
    LodgingId: number;
    Checkin: string;
    Checkout: string;
    RetiredNum: number;
    AdultsNum: number;
    ChildsNum: number;
    BabiesNum: number;
    Name: string;
    Surname: string;
    Mail: string;

    constructor(LodgingId: number, Checkin: string, Checkout: string, RetiredNum: number,
                AdultsNum: number, ChildsNum: number, BabiesNum: number, Name: string, Surname: string, Mail: string) {
        this.LodgingId = LodgingId;
        this.Checkin = Checkin;
        this.Checkout = Checkout;
        this.RetiredNum = RetiredNum;
        this.AdultsNum = AdultsNum;
        this.ChildsNum = ChildsNum;
        this.BabiesNum = BabiesNum;
        this.Name = Name;
        this.Surname = Surname;
        this.Mail = Mail;
    }

}

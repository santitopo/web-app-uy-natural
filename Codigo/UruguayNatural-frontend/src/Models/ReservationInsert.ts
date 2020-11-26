export class ReservationInsert {
    lodgingId: number;
    checkin: string;
    checkout: string;
    retiredNum: number;
    adultsNum: number;
    childsNum: number;
    babiesNum: number;
    name: string;
    surname: string;
    mail: string;

    constructor(LodgingId: number, Checkin: string, Checkout: string, RetiredNum: number,
                AdultsNum: number, ChildsNum: number, BabiesNum: number, Name: string, Surname: string, Mail: string) {
        this.lodgingId = LodgingId;
        this.checkin = Checkin;
        this.checkout = Checkout;
        this.retiredNum = RetiredNum;
        this.adultsNum = AdultsNum;
        this.childsNum = ChildsNum;
        this.babiesNum = BabiesNum;
        this.name = Name;
        this.surname = Surname;
        this.mail = Mail;
    }

}

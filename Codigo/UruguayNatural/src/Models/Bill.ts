export class Bill {
    ReservationCode: number;
    Phone: string;
    Description: string;
    PricePaid: number;

    constructor(ReservationCode: number, Phone: string, Description: string, Price: number) {
      this.ReservationCode = ReservationCode;
      this.Phone = Phone;
      this.Description = Description;
      this.PricePaid = Price;
  }

}

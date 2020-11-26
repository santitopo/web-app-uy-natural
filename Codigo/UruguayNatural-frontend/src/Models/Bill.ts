export class Bill {
    reservationCode: number;
    phone: string;
    description: string;
    pricePaid: number;

    constructor(ReservationCode: number, Phone: string, Description: string, Price: number) {
      this.reservationCode = ReservationCode;
      this.phone = Phone;
      this.description = Description;
      this.pricePaid = Price;
  }

}

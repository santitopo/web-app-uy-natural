export class LodgingSearch {
  tPointId: number;
  checkin: string;
  checkout: string;
  retiredNum: number;
  adultsNum: number;
  childsNum: number;
  babiesNum: number;

  constructor(  TPointId: number, Checkin: string, Checkout: string, RetiredNum: number,
                AdultsNum: number, ChildsNum: number, BabiesNum: number) {
    this.tPointId = TPointId;
    this.checkin = Checkin;
    this.checkout = Checkout;
    this.retiredNum = RetiredNum;
    this.adultsNum = AdultsNum;
    this.childsNum = ChildsNum;
    this.babiesNum = BabiesNum;
  }
}

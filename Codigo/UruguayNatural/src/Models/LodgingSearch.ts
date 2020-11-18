export class LodgingSearch {
  TPointId: number;
  Checkin: string;
  Checkout: string;
  RetiredNum: number;
  AdultsNum: number;
  ChildsNum: number;
  BabiesNum: number;

  constructor(  TPointId: number, Checkin: string, Checkout: string, RetiredNum: number,
                AdultsNum: number, ChildsNum: number, BabiesNum: number) {
    this.TPointId = TPointId;
    this.Checkin = Checkin;
    this.Checkout = Checkout;
    this.RetiredNum = RetiredNum;
    this.AdultsNum = AdultsNum;
    this.ChildsNum = ChildsNum;
    this.BabiesNum = BabiesNum;
  }
}

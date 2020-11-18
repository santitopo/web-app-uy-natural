export class ReservationReport {
        TPointId: string;
        FromDate: string;
        ToDate: string;

  constructor(TPointId: string, FromDate: string, ToDate: string) {
    this.TPointId = TPointId;
    this.FromDate = FromDate;
    this.ToDate = ToDate;
  }

}

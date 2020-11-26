export class ReservationReport {
        TPointId: number;
        FromDate: string;
        ToDate: string;

  constructor(TPointId: number, FromDate: string, ToDate: string) {
    this.TPointId = TPointId;
    this.FromDate = FromDate;
    this.ToDate = ToDate;
  }

}

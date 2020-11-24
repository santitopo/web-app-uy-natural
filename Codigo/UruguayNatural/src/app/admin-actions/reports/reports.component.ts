import { Component, OnInit } from '@angular/core';
import { TPointsService } from 'src/app/services/tpoints.service';
import { ReservationReport } from 'src/Models/ReservationReport';
import { TPoint } from 'src/Models/TPoint';
import { DatePipe } from '@angular/common';
import { HttpParams } from '@angular/common/http';
import { ReservationsService } from 'src/app/services/reservations.service';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {
  from: Date;
  to: Date;
  fromToString:string;
  toToString:string;
  tpoints;
  selectedTPointId:number;
  params:HttpParams;
  reportResult;

  constructor(private tpointsService: TPointsService, private reservationService: ReservationsService,
    private datePipe: DatePipe) {
  }

  ngOnInit(): void {
    this.tpointsService.getTPoints().subscribe(
      res => {
        this.tpoints = res;
      },
      err => {
        alert('Ups algo salió mal...');
        console.log(err);
      });
  }

  generateReport(): void{
    this.fromToString = this.datePipe.transform(this.from,"ddMMyyyy");
    this.toToString = this.datePipe.transform(this.to,"ddMMyyyy");

    this.params = new HttpParams()
    .set('TPointId', this.selectedTPointId.toString())
    .append('FromDate', this.fromToString)
    .set('ToDate', this.toToString);
    
    this.reservationService.getReservationsReportbyTP(this.params).subscribe(
      res => {
        this.reportResult = res;
      },
      error => {
        alert('No hay reportes para el rango de fechas elegido');
      });


  }
}

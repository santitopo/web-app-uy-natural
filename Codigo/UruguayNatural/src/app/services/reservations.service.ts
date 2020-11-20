import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Reservation } from 'src/Models/Reservation';
import { ReservationReport } from 'src/Models/ReservationReport';
import { ReservationReportResult } from 'src/Models/ReservationReportResult';
import { State } from 'src/Models/State';

@Injectable({
  providedIn: 'root'
})
export class ReservationsService {
  uri = `${environment.baseUrl}/reservations`;
  uri2 = `${environment.baseUrl}/reservations/states`;

  constructor(private http: HttpClient) { }

  getReservations(): Observable<Reservation> {
    const headers = new HttpHeaders().set('token', localStorage.token);

    return this.http.get<Reservation>(this.uri, { headers });
  }

  getStates(): Observable<State> {
    const headers = new HttpHeaders().set('token', localStorage.token);

    return this.http.get<State>(this.uri2, { headers: headers });
  }

  getReservationsReportbyTP(params: HttpParams):Observable<ReservationReportResult>{
    alert(params);
    return this.http.get<ReservationReportResult>(this.uri,{params});
  }

}

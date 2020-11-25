import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Bill } from 'src/Models/Bill';
import { Reservation } from 'src/Models/Reservation';
import { ReservationInsert } from 'src/Models/ReservationInsert';
import { ReservationReport } from 'src/Models/ReservationReport';
import { ReservationReportResult } from 'src/Models/ReservationReportResult';
import { ReservationUpdate } from 'src/Models/ReservationUpdate';
import { State } from 'src/Models/State';
import { StateModel } from 'src/Models/StateModel';

@Injectable({
  providedIn: 'root'
})
export class ReservationsService {
  uri = `${environment.baseUrl}/reservations`;
  uri2 = `${environment.baseUrl}/reservations/states`;
  uri3 = `${environment.baseUrl}/reservations/reports`

  constructor(private http: HttpClient) { }

  getReservations(): Observable<Reservation> {
    const headers = new HttpHeaders().set('token', localStorage.token);

    return this.http.get<Reservation>(this.uri, { headers });
  }

  getStates(): Observable<State> {
    const headers = new HttpHeaders().set('token', localStorage.token);

    return this.http.get<State>(this.uri2, { headers: headers });
  }

  getReservationsReportbyTP(parameters: HttpParams):Observable<ReservationReportResult>{
    const options = { params: parameters };

    return this.http.get<ReservationReportResult>(this.uri3,options);
  }

  getReservation(code: string): Observable<StateModel>{
    return this.http.get<StateModel>(`${this.uri}/${code}`);
  }

  updateReservation(modifiedReservation: ReservationUpdate): Observable<{}> {
    const headers = new HttpHeaders().set('token', localStorage.token);
    return this.http.put(this.uri,modifiedReservation, { headers: headers });
  }

  postReservation(reservation: ReservationInsert):Observable<Bill>{
    return this.http.post<Bill>(this.uri, reservation);
  }

}

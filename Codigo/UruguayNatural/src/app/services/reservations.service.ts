import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Reservation } from 'src/Models/Reservation';
import { State } from 'src/Models/State';
import { StateModel } from 'src/Models/StateModel';

@Injectable({
  providedIn: 'root'
})
export class ReservationsService {
  uri = `${environment.baseUrl}/reservations`;
  uri2 = `${environment.baseUrl}/reservations/states`;

  constructor(private http: HttpClient) {}

  getReservations(): Observable<Reservation> {
    return this.http.get<Reservation>(this.uri);
  }

  getStates(): Observable<State> {
    return this.http.get<State>(this.uri);
  }

  getReservation(code: string): Observable<StateModel>{
    return this.http.get<StateModel>(`${this.uri}/${code}`);
  }

}

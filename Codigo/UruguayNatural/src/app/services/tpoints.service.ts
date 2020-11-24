import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { TouristicPointInsert } from 'src/Models/TouristicPointInsert';
import { TouristicPointOut } from 'src/Models/TouristicPointOut';
import { TPoint } from 'src/Models/TPoint';
import { TpointsSearchModule } from '../tpoints-search/tpoints-search.module';

@Injectable({
  providedIn: 'root'
})
export class TPointsService {
  uri = `${environment.baseUrl}/tpoints`;
  uri2 = `${environment.baseUrl}/tpoints/filter`;
  tpoints: TPoint[] = new Array();


  constructor(private http: HttpClient) {
    this.tpoints.push(
      new TPoint(
        1,
        'Punta del Este',
        'Balneario de playa.',
        'images/pde.jpg',
        'Litoral Este',
        ['Playa', 'Ciudad']
      )
    );
    this.tpoints.push(
      new TPoint(
        2,
        'La Paloma',
        'Balneario de playa rochense, amado por la comunidad surfista.',
        'images/paloma.jpg',
        'Litoral Este',
        ['Playa', 'Balneario']
      )
    );
    this.tpoints.push(
      new TPoint(
        3,
        'Colonia',
        'Primer ciudad de Uruguay. Historia y encanto para cualquiera.',
        'images/colonia.jpg',
        'Litoral Oeste',
        ['Colonial', 'Histórico', 'Patrimonio']
      )
    );
  }
 
  getTPoints(): Observable<TPoint> {
    return this.http.get<TPoint>(this.uri);
  }

  getTPointById(id: number): TPoint {
    return this.tpoints.filter(x => x.id === id)[0];
  }

  getTPointsByRegionCat(parameters: HttpParams): Observable<TPoint>{
    const options = { params: parameters };

    return this.http.get<TPoint>(this.uri2,options);
  }

  addTPoint(tpoint: TouristicPointInsert) : Observable<{}> {
    const headers = new HttpHeaders().set('token', localStorage.token);
    return this.http.post(this.uri, tpoint, { headers: headers });
  }

}


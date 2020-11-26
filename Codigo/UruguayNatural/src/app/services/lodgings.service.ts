import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Lodging } from 'src/Models/Lodging';
import { LodgingInsert } from 'src/Models/LodgingInsert';
import { LodgingModel } from 'src/Models/LodgingModel';
import { LodgingSearchResult } from 'src/Models/LodgingSearchResult';

@Injectable({
  providedIn: 'root'
})
export class LodgingsService {
  lodgingSearchResults: LodgingSearchResult[] = new Array();

  uri = `${environment.baseUrl}/lodgings`;

  constructor(private http: HttpClient) {
    this.lodgingSearchResults.push(
      new LodgingSearchResult(
        200,
        new Lodging(
          1,
          'Casa del Sol',
          null,
          'Bonita cabaña para descansar.',
          'Bahia 3, esquina Flores',
          '098 259945',
          3,
          100,
          ['images/casadelsol.jpg'],
          4,
          true)
      )
    );

  }



  getbyNameandTpoint(name:string, tpointId: number): Observable<Lodging> {
    return this.http.get<Lodging>(this.uri+"?LodgingName="+name+"&TpointId="+tpointId);
   }

  addLodging(lodging: LodgingInsert): Observable<{}> {
    const headers = new HttpHeaders().set('token', localStorage.token);
    return this.http.post(this.uri, lodging, { headers: headers });
  }

  modifyLodgingCapacity(lodging: LodgingModel): Observable<{}>{
    const headers = new HttpHeaders({'token': localStorage.token});
    return this.http.put(this.uri, lodging, { headers: headers });
  }

  getLodgingsByTP(parameters: HttpParams){
    const options = { params: parameters };
    return this.http.get(this.uri, options);
  }

}

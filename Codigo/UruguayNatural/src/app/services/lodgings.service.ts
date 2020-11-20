import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Lodging } from 'src/Models/Lodging';
import { LodgingInsert } from 'src/Models/LodgingInsert';
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

  getResults(): LodgingSearchResult[] {
    return this.lodgingSearchResults;
  }

  getLodgings(): Observable<Lodging> {
    return this.http.get<Lodging>(this.uri);
  }

  addLodging(lodging: LodgingInsert): void {

  }

  modifyLodgingCapacity(lodgingId: number, capacity: boolean){

  }
}

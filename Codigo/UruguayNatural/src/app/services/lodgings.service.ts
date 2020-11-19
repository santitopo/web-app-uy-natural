import { Injectable } from '@angular/core';
import { Lodging } from 'src/Models/Lodging';
import { LodgingInsert } from 'src/Models/LodgingInsert';
import { LodgingSearchResult } from 'src/Models/LodgingSearchResult';
import { TouristicPointInsert } from 'src/Models/TouristicPointInsert';
import { TPoint } from 'src/Models/TPoint';

@Injectable({
  providedIn: 'root'
})
export class LodgingsService {
  lodgingSearchResults: LodgingSearchResult[] = new Array();
  lodgings: Lodging[] = new Array();

  constructor() {

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
    this.lodgings.push(
      new Lodging(
        1,
        'Casa del Sol',
        new TPoint(null,"Pajaros Pintados", null,null,null, null),
        'Bonita cabaña para descansar.',
        'Bahia 3, esquina Flores',
        '098 259945',
        3,
        100,
        ['images/casadelsol.jpg'],
        4,
        false)
    )
  }

  getResults(): LodgingSearchResult[] {
    return this.lodgingSearchResults;
  }

  getLodgings(): Lodging[] {
    return this.lodgings;
  }

  addLodging(lodging: LodgingInsert): void {

  }

  modifyLodgingCapacity(lodgingId: number, capacity: boolean){

  }
}

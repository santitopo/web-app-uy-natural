import { Injectable } from '@angular/core';
import { Lodging } from 'src/Models/Lodging';
import { LodgingSearchResult } from 'src/Models/LodgingSearchResult';

@Injectable({
  providedIn: 'root'
})
export class LodgingsService {
  lodgingSearchResults: LodgingSearchResult[] = new Array();
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
          'images/casadelsol.jpg',
          4,
          true),
      )
    );

  }

  getResults(): LodgingSearchResult[] {
    return this.lodgingSearchResults;
  }
}

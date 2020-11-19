import { Injectable } from '@angular/core';
import { TouristicPointInsert } from 'src/Models/TouristicPointInsert';
import { TPoint } from 'src/Models/TPoint';
import { TpointsSearchModule } from '../tpoints-search/tpoints-search.module';

@Injectable({
  providedIn: 'root'
})
export class TPointsService {

  tpoints: TPoint[] = new Array();
  constructor() {
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

  getTPoints(): TPoint[] {
    return this.tpoints;
  }

  getTPointById(id: number): TPoint {
    return this.tpoints.filter(x => x.id === id)[0];
  }

  addTPoint(tpoint: TouristicPointInsert) : void{

  }
}


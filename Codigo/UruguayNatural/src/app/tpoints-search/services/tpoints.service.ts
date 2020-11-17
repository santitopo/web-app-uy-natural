import { Injectable } from '@angular/core';
import { TPoint } from 'src/Models/TPoint';

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
        'assets/images/tpoint1.png'
      )
    );
    this.tpoints.push(
      new TPoint(
        2,
        'La Paloma',
        'Balneario de playa rochense, amado por la comunidad surfista.',
        'assets/images/tpoint2.png'
      )
    );
    this.tpoints.push(
      new TPoint(
        3,
        'Colonia',
        'Primer ciudad de Uruguay. Historia y encanto para cualquiera.',
        'assets/images/tpoint3.png'
      )
    );
    
  }

  getTPoints(): TPoint[] {
    return this.tpoints;
  }

  getTPointById(id: number): TPoint {
    return this.tpoints.filter(x => x.id === id)[0];
  }
}


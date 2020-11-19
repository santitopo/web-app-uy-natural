import { Injectable } from '@angular/core';
import { Region } from 'src/Models/Region';

@Injectable({
  providedIn: 'root'
})
export class RegionsService {
  regions: Region[] = new Array();
  constructor() {
    this.regions.push(
      new Region(
        1,
        'Metropolitana',
      )
    );
    this.regions.push(
      new Region(
        2,
        'CentroSur',
      )
    );
    this.regions.push(
      new Region(
        3,
        'Pajaros Pintados',
      )
    );
    this.regions.push(
      new Region(
        4,
        'Litoral Norte',
      )
    );
    this.regions.push(
      new Region(
        5,
        'Este',
      )
    );
  }

  getRegions(): Region[] {
    return this.regions;
  }
}



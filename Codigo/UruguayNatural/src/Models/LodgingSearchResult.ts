import { Lodging } from './Lodging';

export class LodgingSearchResult {
    price: number;
    lodging: Lodging;
  
    constructor(price: number, lodging: Lodging) {
      this.price = price;
      this.lodging = lodging;
  }

}
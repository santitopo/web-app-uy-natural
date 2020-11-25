import { Lodging } from './Lodging';

export class LodgingSearchResult {
    totalPrice: number;
    lodging: Lodging;

    constructor(price: number, lodging: Lodging) {
      this.totalPrice = price;
      this.lodging = lodging;
  }

}

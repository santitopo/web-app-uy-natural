import { TPoint } from './TPoint';

export class Lodging {
    id: number;
    name: string;
    touristicPoint: TPoint;
    description: string;
    direction: string;
    phone: string;
    stars: number;
    price: number;
    images: string[];
    score: number;
    capacity: boolean;

    constructor(Id: number, Name: string, TouristicPoint: TPoint, Description: string, Direction: string,
                Phone: string, Stars: number, Price: number, Images: string[], Score: number, Capacity: boolean) {
      this.id = Id;
      this.name = Name;
      this.description = Description;
      this.direction = Direction;
      this.phone = Phone;
      this.images = Images;
      this.price = Price;
      this.score = Score;
      this.stars = Stars;
      this.touristicPoint = TouristicPoint;
      this.capacity = Capacity;

  }

}

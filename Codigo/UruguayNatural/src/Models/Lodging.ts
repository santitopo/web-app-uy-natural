import { TPoint } from './TPoint';

export class Lodging {
    Id: number;
    Name: string;
    TouristicPoint: TPoint;
    Description: string;
    Direction: string;
    Phone: string;
    Stars: number;
    Price: number;
    Images: string[];
    Score: number;
    Capacity: boolean;

    constructor(Id: number, Name: string, TouristicPoint: TPoint, Description: string, Direction: string,
                Phone: string, Stars: number, Price: number, Images: string[], Score: number, Capacity: boolean) {
      this.Id = Id;
      this.Name = Name;
      this.Description = Description;
      this.Direction = Direction;
      this.Phone = Phone;
      this.Images = Images;
      this.Price = Price;
      this.Score = Score;
      this.Stars = Stars;
      this.TouristicPoint = TouristicPoint;
      this.Capacity = Capacity;

  }

}

export class LodgingInsert {
    Id: number;
    Name: string;
    TPointId: number;
    Description: string;
    Direction: string;
    Phone: string;
    Stars: number;
    Price: number;
    Images: string[];
    Score: number;
    Capacity: boolean;

    constructor(Name: string, TPointId: number, Description: string, Direction: string,
                Phone: string, Stars: number, Price: number, Images: string[]) {
      this.Name = Name;
      this.Description = Description;
      this.Direction = Direction;
      this.Phone = Phone;
      this.Images = Images;
      this.Price = Price;
      this.Stars = Stars;
      this.TPointId = TPointId;
      this.Capacity = true;
      this.Score = 0;
  }

}

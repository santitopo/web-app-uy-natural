export class LodgingModel {
    Id: number;
    Name: string;
    TPointId: number;
    Description: string;
    Direction: string;
    Phone: string;
    Stars: number;
    Price: number;
    Images: string;
    IsFull: boolean;

    constructor(Id: number, Name: string, TPointId: number, Description: string, Direction: string,
                Phone: string, Stars: number, Price: number, Images: string, IsFull: boolean) {
      this.Id = Id;
      this.Name = Name;
      this.Description = Description;
      this.Direction = Direction;
      this.Phone = Phone;
      this.Images = Images;
      this.Price = Price;
      this.Stars = Stars;
      this.TPointId = TPointId;
      this.IsFull = IsFull;

  }

}

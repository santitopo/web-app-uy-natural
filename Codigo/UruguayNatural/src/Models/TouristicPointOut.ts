import { Category } from './Category';
import { Region } from './Region';

export class TouristicPointInsert {
    Name: string;
    Description: string;
    Image: string;
    Id: number;
    Region: Region;
    //Categories: ?;

   constructor( Name: string, Description: string, Image: string, Id: number, Region: Region) {
       this.Name = Name;
       this.Description = Description;
       this.Image = Image;
       this.Id = Id;
       this.Region = Region;
   }

}

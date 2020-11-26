export class TouristicPointInsert {
     Name: string;
     Description: string;
     Image: string;
     RegionId: number;
     Categories: number[];

    constructor( Name: string, Description: string, Image: string,  RegionId: number, Categories: number[]) {
        this.Name = Name;
        this.Description = Description;
        this.Image = Image;
        this.RegionId = RegionId;
        this.Categories = Categories;
    }

}

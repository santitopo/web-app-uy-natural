export class TPoint {
    id: number;
    name: string;
    description: string;
    image: string;
    region: string;
    categories: string[];
  
    constructor(id: number, name: string, description: string, image: string, region: string,
                categories: string[]) {
      this.id = id;
      this.name = name;
      this.description = description;
      this.image = image;
      this.region = region;
      this.categories = categories;
    }
  }

 
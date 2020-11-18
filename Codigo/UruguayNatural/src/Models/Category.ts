export class Category {
    id: number;
    name: string;
    touristicPoints : string[];
  
    constructor(id: number, name: string, touristicPoints: string[]) {
      this.id = id;
      this.name = name;
      this.touristicPoints = touristicPoints;
  }

}
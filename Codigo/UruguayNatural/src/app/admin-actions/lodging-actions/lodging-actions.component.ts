import { Component, OnInit } from '@angular/core';
import { TPointsService } from 'src/app/services/tpoints.service';
import { TPoint } from 'src/Models/TPoint';
import { LodgingInsert } from 'src/Models/LodgingInsert';
import { LodgingsService } from 'src/app/services/lodgings.service';
import { Lodging } from 'src/Models/Lodging';


@Component({
  selector: 'app-lodging-actions',
  templateUrl: './lodging-actions.component.html',
  styleUrls: ['./lodging-actions.component.css']
})
export class LodgingActionsComponent implements OnInit {
  //Add Lodging Variables
  tpoints;
  starRating = 3;
  name:string;
  direction:string;
  phone:string;
  price:number;
  selectedTPointId:number;
  description:string;
  images:string[];

  //Modify Capacity Variables
  lodgings;
  selectedLodging: Lodging;
  actualCapacity: string;
  selectedCapacity: string;


  constructor(private tpointsService: TPointsService, private lodgingService: LodgingsService) {
  }

  ngOnInit(): void {
    this.tpointsService.getTPoints().subscribe(
      res => {
        this.tpoints = res;
      },
      err => {
        alert('Ups algo salió mal...');
        console.log(err);
      });

      /*
      this.lodgingService.getLodgings().subscribe(
        res => {
          this.lodgings = res;
        },
        err => {
          alert('Ups algo salió mal...');
          console.log(err);
        });
        */
  }

  addLodging(): void{
    const lodging = new LodgingInsert(this.name, this.selectedTPointId, this.description, this.direction,
      this.phone, this.starRating, this.price, this.images);

      this.lodgingService.addLodging(lodging);
  }

  modifyCapacity(): void{

    if (this.selectedCapacity = "Disponible") {
      this.lodgingService.modifyLodgingCapacity(this.selectedLodging.Id, true);
    } 
    else {
      this.lodgingService.modifyLodgingCapacity(this.selectedLodging.Id, false);
    }
    
  }

  select(lodging:Lodging): void{
    if(lodging.Capacity){
      this.actualCapacity = "Disponible";
    }else{
      this.actualCapacity = "Lleno";
    }
  }

}

import { Component, OnInit } from '@angular/core';
import { TPointsService } from 'src/app/services/tpoints.service';
import { TPoint } from 'src/Models/TPoint';
import { LodgingInsert } from 'src/Models/LodgingInsert';
import { LodgingsService } from 'src/app/services/lodgings.service';
import { Lodging } from 'src/Models/Lodging';
import { Router } from '@angular/router';
import { LodgingModel } from 'src/Models/LodgingModel';


@Component({
  selector: 'app-lodging-actions',
  templateUrl: './lodging-actions.component.html',
  styleUrls: ['./lodging-actions.component.css']
})
export class LodgingActionsComponent implements OnInit {
 //Both
  tpoints;

   //Add Lodging Variables
  starRating = 3;
  name:string;
  direction:string;
  phone:string;
  price:number;
  selectedTPointId:number;
  description:string;
  images:string[];

  //Modify Capacity Variables
  selectedTPointIdSearch:number;
  lodgings;
  Arr = Array;
  LodgingName: string;
  selectedLodging: Lodging;
  actualCapacity: string;
  selectedCapacity: string;
  capacity: boolean;
  searched:boolean;


  constructor(private tpointsService: TPointsService, private lodgingService: LodgingsService, private router: Router) {
    this.lodgings = new Array();
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
  }

  addLodging(): void{
    const lodging = new LodgingInsert(this.name, this.selectedTPointId, this.description, this.direction,
      this.phone, this.starRating, this.price, this.images);

      this.lodgingService.addLodging(lodging).subscribe();
  }

  modifyCapacity(): void{
    if (this.selectedCapacity == "available") {
      this.capacity = true;
    } 
    else if (this.selectedCapacity == "full"){
      this.capacity = false;
    }
    else{
      this.capacity = false;
    }

    let modifiedlodging = new LodgingModel(this.selectedLodging.id, undefined, undefined, undefined, undefined, undefined,
      undefined,undefined,undefined, !this.capacity);
    this.lodgingService.modifyLodgingCapacity(modifiedlodging).subscribe(
      res => {
        this.router.navigate(['/success']);
      },
      err => {
        alert("Ups.. Algo salió mal");
        console.log(err);
      }


    );
  }

  select(lodging:Lodging): void{
    if(lodging.capacity){
      this.actualCapacity = "Disponible";
    }else{
      this.actualCapacity = "Lleno";
    }
  }

  importLodging(): void{
    this.router.navigate(['/tpointimportation']);
  }

  searchLodgings(): void{
    
    this.selectedLodging = undefined;
     this.lodgingService.getbyNameandTpoint(this.LodgingName,this.selectedTPointIdSearch).subscribe(
      res => {
        this.lodgings = res;
        this.searched = true;
      },
      err => {
        alert("Ups.. Algo salió mal");
        console.log(err);
      }
    )
  }

}

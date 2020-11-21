import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TPointsService } from 'src/app/services/tpoints.service';
import { TPoint } from 'src/Models/TPoint';

@Component({
  selector: 'tpoint-cards',
  templateUrl: './tpoint-cards.component.html',
  styleUrls: ['./tpoint-cards.component.css']
})
export class TpointCardsComponent implements OnInit {
  tpoints;
  constructor(private tpointsService: TPointsService, private router: Router) { 
    
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

  getDetail(tpointId:number){
    this.router.navigate(['/lodgingsearch']);
  }

}

import { Component, OnInit } from '@angular/core';
import { TPointsService } from 'src/app/services/tpoints.service';
import { TPoint } from 'src/Models/TPoint';

@Component({
  selector: 'tpoint-cards',
  templateUrl: './tpoint-cards.component.html',
  styleUrls: ['./tpoint-cards.component.css']
})
export class TpointCardsComponent implements OnInit {
  tpoints: TPoint[];
  Arr = Array;
  constructor(private tpointsService: TPointsService) { this.tpoints = new Array();}

  ngOnInit(): void {
    this.tpoints = this.tpointsService.getTPoints();
  }

}

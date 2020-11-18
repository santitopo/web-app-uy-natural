import { Component, OnInit } from '@angular/core';
import { TPoint } from 'src/Models/TPoint';
import { TPointsService } from '../services/tpoints.service';

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

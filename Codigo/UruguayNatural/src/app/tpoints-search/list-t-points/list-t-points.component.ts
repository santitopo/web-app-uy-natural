import { Component, OnInit } from '@angular/core';
import { TPoint } from 'src/Models/TPoint';
import { TPointsService } from '../services/tpoints.service';

@Component({
  selector: 'app-list-t-points',
  templateUrl: './list-t-points.component.html',
  styleUrls: ['./list-t-points.component.css']
})
export class ListTPointsComponent implements OnInit {
  tpoints: TPoint[];
  Arr = Array;
  constructor(private tpointsService: TPointsService) {
    this.tpoints = new Array();
  }

  ngOnInit(): void{
    this.tpoints = this.tpointsService.getTPoints();
  }

}

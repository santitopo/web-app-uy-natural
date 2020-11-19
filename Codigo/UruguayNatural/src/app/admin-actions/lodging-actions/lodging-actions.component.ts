import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-lodging-actions',
  templateUrl: './lodging-actions.component.html',
  styleUrls: ['./lodging-actions.component.css']
})
export class LodgingActionsComponent implements OnInit {
  starRating = 3;
  
  constructor() { }

  ngOnInit(): void {
  }

}

import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-review-form',
  templateUrl: './review-form.component.html',
  styleUrls: ['./review-form.component.css']
})
export class ReviewFormComponent implements OnInit {

  starRating = 3;

  constructor() { }

  ngOnInit(): void {
  }

}

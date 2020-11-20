import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ReservationsService } from 'src/app/services/reservations.service';
import { ReviewsService } from 'src/app/services/reviews.service';
import { State } from 'src/Models/State';
import { StateModel } from 'src/Models/StateModel';

import { Review } from 'src/Models/Review';
import { ReviewModel } from 'src/Models/ReviewModel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-review-form',
  templateUrl: './review-form.component.html',
  styleUrls: ['./review-form.component.css']
})
export class ReviewFormComponent implements OnInit {
  stateName: string;
  description: string;

  reviewDescription: string;
  reviewStars: number;
  reservationCode: string;
  
  starRating = 3;
  showState= false;
  showReviewArea = false;
  showNotFound = false;

  constructor(private reservationService:ReservationsService, private reviewService: ReviewsService
    , private router: Router) { this.reviewStars=0;}

  ngOnInit(): void {
  }

  handlerFunction(valueEmitted){
    this.reservationCode = valueEmitted;
    this.loadReservation(valueEmitted);
  }

  loadReservation(reservationCode:string){
    this.reservationService.getReservation(reservationCode).subscribe(
      (res: StateModel) => {       
          this.description = res.description;
          this.stateName = res.name;
          this.showNotFound=false;
          this.showState=true;

      },
      err => {
          this.showState=false;
        this.showNotFound= true;
      } 
    );
  }


  allowReview(){
    this.showReviewArea = true;
  }

  sendReview(){
    this.reviewService.sendReview(new ReviewModel(this.reviewDescription,this.reviewStars,this.reservationCode)).subscribe(
      (res: Review) => {
        this.router.navigate(['/success']);
      },
      err => {
        console.log(err);
      }
    );
  }


}

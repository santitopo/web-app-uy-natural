import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Review } from 'src/Models/Review';
import { ReviewModel } from 'src/Models/ReviewModel';

@Injectable({
  providedIn: 'root'
})
export class ReviewsService {
  uri = `${environment.baseUrl}/reviews`;
  constructor(private http: HttpClient) { }

  sendReview(review: ReviewModel): Observable<Review>{
    return this.http.post<Review>(this.uri, review);
  }

  checkExistingReview(reservationCode: string): Observable<boolean>{
    return this.http.get<boolean>(`${this.uri}/${reservationCode}`);
  }

  getReviewsByLodging(lodgingId: number): Observable<Review>{
    return this.http.get<Review>(`${this.uri}/lodging/${lodgingId}`);
  }

}

import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReservationComunicationService {
  constructor(){}
  
  //Using any
  public editDataDetails: any = [];
  public subject = new Subject<any>();
  private messageSource = new  BehaviorSubject(this.editDataDetails);
  currentMessage = this.messageSource.asObservable();
  
  changeMessage(lodgingSearch: any, lodgingSearchResult: any) {    
  this.messageSource.next([lodgingSearch,lodgingSearchResult]);
  }
  }

import { TestBed } from '@angular/core/testing';

import { ReservationComunicationService } from './reservation-comunication.service';

describe('ReservationComunicationService', () => {
  let service: ReservationComunicationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReservationComunicationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

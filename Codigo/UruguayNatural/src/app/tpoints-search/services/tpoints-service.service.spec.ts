import { TestBed } from '@angular/core/testing';

import { TPointsService } from './tpoints.service';

describe('TPointsServiceService', () => {
  let service: TPointsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TPointsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

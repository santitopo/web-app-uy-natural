import { TestBed } from '@angular/core/testing';

import { isLoggedGuard } from './isLogged.guard';

describe('isLoggedGuard', () => {
  let guard: isLoggedGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(isLoggedGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});

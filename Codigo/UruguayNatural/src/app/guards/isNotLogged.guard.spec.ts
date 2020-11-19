import { TestBed } from '@angular/core/testing';

import { isNotLoggedGuard } from './isNotLogged.guard';

describe('isLoggedGuard', () => {
  let guard: isNotLoggedGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(isNotLoggedGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReservationActionsComponent } from './reservation-actions.component';

describe('ReservationActionsComponent', () => {
  let component: ReservationActionsComponent;
  let fixture: ComponentFixture<ReservationActionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReservationActionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReservationActionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

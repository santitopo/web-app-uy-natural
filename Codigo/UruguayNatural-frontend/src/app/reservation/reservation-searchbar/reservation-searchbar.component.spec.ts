import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReservationSearchbarComponent } from './reservation-searchbar.component';

describe('ReservationSearchbarComponent', () => {
  let component: ReservationSearchbarComponent;
  let fixture: ComponentFixture<ReservationSearchbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReservationSearchbarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReservationSearchbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

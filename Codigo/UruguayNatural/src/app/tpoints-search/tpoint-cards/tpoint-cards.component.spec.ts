import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TpointCardsComponent } from './tpoint-cards.component';

describe('TpointCardsComponent', () => {
  let component: TpointCardsComponent;
  let fixture: ComponentFixture<TpointCardsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TpointCardsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TpointCardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

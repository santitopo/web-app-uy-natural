import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TpointCardComponent } from './tpoint-card.component';

describe('TpointCardComponent', () => {
  let component: TpointCardComponent;
  let fixture: ComponentFixture<TpointCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TpointCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TpointCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

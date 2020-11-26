import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LodgingActionsComponent } from './lodging-actions.component';

describe('LodgingActionsComponent', () => {
  let component: LodgingActionsComponent;
  let fixture: ComponentFixture<LodgingActionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LodgingActionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LodgingActionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

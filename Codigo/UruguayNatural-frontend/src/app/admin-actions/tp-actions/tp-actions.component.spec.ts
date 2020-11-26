import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TpActionsComponent } from './tp-actions.component';

describe('TpActionsComponent', () => {
  let component: TpActionsComponent;
  let fixture: ComponentFixture<TpActionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TpActionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TpActionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

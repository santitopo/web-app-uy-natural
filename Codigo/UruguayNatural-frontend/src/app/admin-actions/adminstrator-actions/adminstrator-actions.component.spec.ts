import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminstratorActionsComponent } from './adminstrator-actions.component';

describe('AdminstratorActionsComponent', () => {
  let component: AdminstratorActionsComponent;
  let fixture: ComponentFixture<AdminstratorActionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminstratorActionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminstratorActionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

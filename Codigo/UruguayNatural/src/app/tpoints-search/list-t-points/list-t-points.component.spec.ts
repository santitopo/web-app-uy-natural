import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListTPointsComponent } from './list-t-points.component';

describe('ListTPointsComponent', () => {
  let component: ListTPointsComponent;
  let fixture: ComponentFixture<ListTPointsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListTPointsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListTPointsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

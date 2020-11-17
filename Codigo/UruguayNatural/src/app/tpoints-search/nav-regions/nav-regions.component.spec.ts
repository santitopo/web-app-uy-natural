import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavRegionsComponent } from './nav-regions.component';

describe('NavRegionsComponent', () => {
  let component: NavRegionsComponent;
  let fixture: ComponentFixture<NavRegionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NavRegionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NavRegionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

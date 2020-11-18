import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportBodyComponent } from './import-body.component';

describe('ImportBodyComponent', () => {
  let component: ImportBodyComponent;
  let fixture: ComponentFixture<ImportBodyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImportBodyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImportBodyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

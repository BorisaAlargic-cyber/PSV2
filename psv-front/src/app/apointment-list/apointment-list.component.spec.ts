import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApointmentListComponent } from './apointment-list.component';

describe('ApointmentListComponent', () => {
  let component: ApointmentListComponent;
  let fixture: ComponentFixture<ApointmentListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApointmentListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApointmentListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

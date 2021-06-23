import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddApointmentComponent } from './add-apointment.component';

describe('AddApointmentComponent', () => {
  let component: AddApointmentComponent;
  let fixture: ComponentFixture<AddApointmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddApointmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddApointmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

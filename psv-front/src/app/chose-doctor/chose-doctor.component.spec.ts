import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChoseDoctorComponent } from './chose-doctor.component';

describe('ChoseDoctorComponent', () => {
  let component: ChoseDoctorComponent;
  let fixture: ComponentFixture<ChoseDoctorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChoseDoctorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChoseDoctorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

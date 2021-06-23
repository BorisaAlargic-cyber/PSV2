import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApointmentService } from '../services/apointmentService';
import { UserService } from '../services/userService';


@Component({
  selector: 'app-add-apointment',
  templateUrl: './add-apointment.component.html',
  styleUrls: ['./add-apointment.component.scss']
})
export class AddApointmentComponent implements OnInit {

  addAppointmentForm : FormGroup;
  doctors;

  constructor(private formBuilder: FormBuilder, private userService: UserService ,private apointmentService : ApointmentService) { }

  ngOnInit(): void {
    this.addAppointmentForm = this.formBuilder.group({
      date: [null, Validators.required],
      doctor: [null, Validators.required],
    });

    this.doctors = [];

    this.userService.getDoctors().subscribe(data => {
      this.doctors = data;

    });

  }



  submit() {

    if (!this.addAppointmentForm.valid) {
      return;
    }

    this.apointmentService.addApointment({
      doctor: { id: this.addAppointmentForm.value.doctor} ,
      date: this.addAppointmentForm.value.date,
    }).subscribe(data => {
      
    });
  }

}

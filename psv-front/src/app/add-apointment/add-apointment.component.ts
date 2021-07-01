import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApointmentService } from '../services/apointmentService';
import { UserService } from '../services/userService';
import { Router } from '@angular/router';


@Component({
  selector: 'app-add-apointment',
  templateUrl: './add-apointment.component.html',
  styleUrls: ['./add-apointment.component.scss']
})
export class AddApointmentComponent implements OnInit {

  addAppointmentForm: FormGroup;
  doctors: any;

  constructor(private formBuilder: FormBuilder, private userService: UserService, private apointmentService: ApointmentService, private router: Router) { }

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
    this.apointmentService.addApointment({
      doctor: { id: parseInt(this.addAppointmentForm.value.doctor) },
      date: this.addAppointmentForm.value.date,
    }).subscribe(data => {
      this.router.navigate(['/apointments']);
    });
  }

}

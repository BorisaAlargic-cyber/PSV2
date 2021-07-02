import { getLocaleDateFormat } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApointmentService } from '../services/apointmentService';
import { UserService } from '../services/userService';
import { Router } from '@angular/router';


export interface Apointment {
  paitent: string,
  doctor: string,
  dateFrom: string,
  dateTo: string,
}

@Component({
  selector: 'app-apointment-list',
  templateUrl: './apointment-list.component.html',
  styleUrls: ['./apointment-list.component.scss']
})
export class ApointmentListComponent implements OnInit {

  searchAppointmentForm: FormGroup;
  doctors;
  user: any;


  elements: Apointment[] = []
  displayedColumns: string[] = ['patient', 'date', 'doctor', 'taken']

  constructor(private apointmentService: ApointmentService, private formBuilder: FormBuilder, private userService: UserService, private router: Router) { }


  ngOnInit(): void {

    this.searchAppointmentForm = this.formBuilder.group({
      dateFrom: [null, Validators.required],
      dateTo: [null, Validators.required],
      doctor: [null, Validators.required],
      priority: [null, Validators.required],
    });

    this.user = JSON.parse(localStorage.getItem('user'));
    console.log(this.user);

    this.apointmentService.getApointment().subscribe(data => {
      this.elements = data['entities'];
      console.log(data);


      this.doctors = [];

      this.userService.getDoctors().subscribe(data => {
        this.doctors = data;

      });
    })
  }


  toInstruction(id) {

    this.router.navigate(['/create-instruction'], { queryParams: { id: id } });
  }

  takeApointment(event, element) {
    this.apointmentService.takeApointment(element.id).subscribe(data => {
      this.ngOnInit();
    })
  }
  leaveApointment(event, element) {
    this.apointmentService.leaveApointment(element.id).subscribe(data => {
      this.ngOnInit();
    })
  }
  searchOnClick() {
    this.apointmentService.searchApointment({
      from: this.searchAppointmentForm.value.dateFrom,
      to: this.searchAppointmentForm.value.dateTo,
      doctor: { id: parseInt(this.searchAppointmentForm.value.doctor) },
      priority: this.searchAppointmentForm.value.priority
    }).subscribe((data: any) => {
      this.elements = data;
    })
  }

}

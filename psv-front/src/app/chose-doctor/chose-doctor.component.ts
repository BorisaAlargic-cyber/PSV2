import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../services/userService';
import { Router } from '@angular/router';


@Component({
  selector: 'app-chose-doctor',
  templateUrl: './chose-doctor.component.html',
  styleUrls: ['./chose-doctor.component.scss']
})
export class ChoseDoctorComponent implements OnInit {



  choseDoctorForm: FormGroup;
  doctors: any;

  constructor(private formBuilder: FormBuilder, private userService: UserService, private router: Router) { }

  ngOnInit(): void {
    this.choseDoctorForm = this.formBuilder.group({
      doctor: [null, Validators.required],
    });

    this.doctors = [];

    this.userService.getDoctors().subscribe(data => {
      this.doctors = data;
    });

  }

  submit() {


    this.userService.choseDoctor({
      id: parseInt(this.choseDoctorForm.controls['doctor'].value)
    }).subscribe(data => {
      this.router.navigate(['/home']);
    })
  }

}

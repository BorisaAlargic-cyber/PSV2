import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../services/userService';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  registrationForm: FormGroup;
  emailRegx = /^(([^<>+()\[\]\\.,;:\s@"-#$%&=]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,3}))$/;


  constructor(private formBuilder: FormBuilder, private userService: UserService,
    private router: Router) { }

  ngOnInit(): void {
    this.registrationForm = this.formBuilder.group({
      email: [null, [Validators.required, Validators.pattern(this.emailRegx)]],
      password: [null, Validators.required],
      firstName: [null, Validators.required],
      lastName: [null, Validators.required]
    });
  }

  submit() {

    if (!this.registrationForm.valid) {
      return;
    }


    this.userService.register(this.registrationForm.value).subscribe((data) => {
      this.router.navigate(['/login']);
    });
  }

}

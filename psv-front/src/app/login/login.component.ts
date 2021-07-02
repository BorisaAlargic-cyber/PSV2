import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TokenService } from '../services/tokenService';
import { UserService } from '../services/userService';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  emailRegx = /^(([^<>+()\[\]\\.,;:\s@"-#$%&=]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,3}))$/;

  constructor(private formBuilder: FormBuilder, private tokenService: TokenService, private router: Router,
    private userService: UserService) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: [null, [Validators.required, Validators.pattern(this.emailRegx)]],
      password: [null, Validators.required]
    });
  }

  submit() {

    if (!this.loginForm.valid) {
      return;
    }

    this.tokenService.token(this.loginForm.value).subscribe((data) => {
      localStorage.setItem('token', JSON.stringify(data));

      this.userService.getUser().subscribe((data: any) => {

        console.log('test', data.choosenDoctor, data.role)

        if (data.choosenDoctor == null && data.role == 'PATIENT') {
          this.router.navigate(['/chose-doctor']);
          return;
        }

        localStorage.setItem('user', JSON.stringify(data));

        this.router.onSameUrlNavigation = 'reload';
        //this.router.navigate(['/home']);

        window.location.href = '/home'

      });


    });
  }
}
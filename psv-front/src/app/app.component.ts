import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'psv-front';

  isLogedIn = false;
  isAdmin = false;
  isDoctor = false;
  isPatient = false;

  constructor(private router: Router) { }

  logout() {

    localStorage.removeItem('token');
    localStorage.removeItem('user');

    this.router.navigate(['/login']);
  }

  ngOnInit() {

    let user = JSON.parse(localStorage.getItem('user'));

    console.log(user, "app");

    if (user) {
      this.isLogedIn = true;
    }

    if (user && user.role == "ADMIN") {
      this.isAdmin = true;
    }

    if (user && user.role == "DOCTOR") {
      this.isDoctor = true;
    }

    if (user && user.role == "PATIENT") {
      this.isPatient = true;
    }
  }
}



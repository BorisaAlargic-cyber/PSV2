import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddApointmentComponent } from './add-apointment/add-apointment.component';
import { AddDrugComponent } from './add-drug/add-drug.component';
import { AddFeedbackComponent } from './add-feedback/add-feedback.component';
import { ApointmentListComponent } from './apointment-list/apointment-list.component';
import { AppComponent } from './app.component';
import { ChoseDoctorComponent } from './chose-doctor/chose-doctor.component';
import { DrugListComponent } from './drug-list/drug-list.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { UserListComponent } from './user-list/user-list.component';
import { VisitComponent } from './visit/visit.component';


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'registration', component: RegistrationComponent },
  { path: 'add-feedback', component: AddFeedbackComponent },
  { path: 'feedback', component: FeedbackComponent },
  { path: 'users', component: UserListComponent },
  { path: 'drugs', component: DrugListComponent },
  { path: 'add-drug', component: AddDrugComponent },
  { path: 'add-appointment', component: AddApointmentComponent },
  { path: 'apointments', component: ApointmentListComponent },
  { path: 'chose-doctor', component: ChoseDoctorComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

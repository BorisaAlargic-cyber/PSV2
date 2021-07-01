import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input'
import { MatCardModule } from '@angular/material/card';
import { FeedbackComponent } from './feedback/feedback.component';
import { AddFeedbackComponent } from './add-feedback/add-feedback.component'
import { MatTableModule } from '@angular/material/table'
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { UserService } from './services/userService';
import { TokenService } from './services/tokenService';
import { FeedBackService } from './services/feedbackService';
import { TokenInterceptor } from './services/tokenInterceptor';
import { UserListComponent } from './user-list/user-list.component';
import { VisitComponent } from './visit/visit.component';
import { VisitService } from './services/visitService';
import { DrugListComponent } from './drug-list/drug-list.component';
import { DrugService } from './services/drugService';
import { AddDrugComponent } from './add-drug/add-drug.component';
import { AddApointmentComponent } from './add-apointment/add-apointment.component';
import {
  NgxMatDatetimePickerModule, NgxMatTimepickerModule,
  NgxMatNativeDateModule
} from '@angular-material-components/datetime-picker';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { ApointmentListComponent } from './apointment-list/apointment-list.component';
import { HomeComponent } from './home/home.component';
import { ApointmentService } from './services/apointmentService';
import { TerminService } from './services/terminService';
import { ChoseDoctorComponent } from './chose-doctor/chose-doctor.component';
import { MatSelectModule } from '@angular/material/select';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    FeedbackComponent,
    AddFeedbackComponent,
    UserListComponent,
    VisitComponent,
    DrugListComponent,
    AddDrugComponent,
    AddApointmentComponent,
    ApointmentListComponent,
    HomeComponent,
    ChoseDoctorComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule, ReactiveFormsModule,
    CommonModule,
    MatButtonModule, MatFormFieldModule, MatInputModule,
    MatCardModule,
    MatTableModule,
    HttpClientModule,
    NgxMatDatetimePickerModule,
    MatSelectModule,
    NgxMatTimepickerModule, MatDatepickerModule, NgxMatNativeDateModule,
  ],
  providers: [UserService, TokenService, FeedBackService, VisitService, DrugService, ApointmentService, TerminService,
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

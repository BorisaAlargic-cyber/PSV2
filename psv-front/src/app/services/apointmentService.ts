import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class ApointmentService
{
    baseUrl = 'https://localhost:44308';

    constructor(private http: HttpClient) { }

    getApointment(){
       return this.http.get(this.baseUrl + '/api/apointment/pointment-all');
    }
    addApointment(input){
       return this.http.post(this.baseUrl + '/api/apointment/add',input);
    }

    takeApointment(id){
       return this.http.put(this.baseUrl + '/api/apointment/take/'+ id ,{});
    }
    leaveApointment(id){
       return this.http.put(this.baseUrl + '/api/apointment/leave/' + id, {});
    }




}
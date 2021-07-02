import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class UserService {

    baseUrl = 'https://localhost:5001';

    constructor(private http: HttpClient) { }


    register(data) {
        return this.http.post(this.baseUrl + '/api/users', data);
    }

    getUser() {
        return this.http.get(this.baseUrl + '/api/users/get-current');
    }

    getAllUsers() {
        return this.http.get(this.baseUrl + '/api/users/get-all');
    }

    getDoctors() {
        return this.http.get(this.baseUrl + '/api/users/get-doctors');
    }

    blockUser(email) {
        return this.http.post(this.baseUrl + '/api/users/block/' + email, {});
    }

    unBlockUser(email) {
        return this.http.post(this.baseUrl + '/api/users/unblock/' + email, {});
    }

    choseDoctor(doctor) {
        return this.http.post(this.baseUrl + '/api/users/set-doctor', doctor);
    }
    blockinUsers() {
        return this.http.post(this.baseUrl + '/api/apointments/count-left', {});
    }
}
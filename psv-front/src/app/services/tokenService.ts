import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class TokenService{

    baseUrl = 'https://localhost:44308';
  
    constructor(private http: HttpClient) { }


    token(data) {
        return this.http.post(this.baseUrl + '/api/token', data);
    }
}
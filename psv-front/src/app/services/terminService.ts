import { Injectable, InjectionToken } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class TerminService{
    
    baseUrl = 'https://localhost:44308';

    constructor(private http: HttpClient) { }

    termin(data) {
        return this.http.post(this.baseUrl + '/api/termin', data);
    }
}
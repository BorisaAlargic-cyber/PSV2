import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class VisitService
{
    baseUrl = 'https://localhost:44308';
  
    constructor(private http: HttpClient) { }

    getAllVists(){
        return this.http.get(this.baseUrl + '/api/visit/get-all');
    }
}
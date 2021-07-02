import { Injectable, InjectionToken } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class InstructionService {

    baseUrl = 'https://localhost:5001';

    constructor(private http: HttpClient) { }

    createInstruction(input) {
        return this.http.post(this.baseUrl + '/api/instructions/create', input);
    }

}
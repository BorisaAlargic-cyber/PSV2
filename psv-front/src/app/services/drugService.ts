import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class DrugService
{
    baseUrl = 'https://localhost:44308';

    constructor(private http: HttpClient) { }

    getAllDrugs(){
        return this.http.get(this.baseUrl + '/api/drugs/get-all')
    }
    deleteDrug(id){
        return this.http.delete(this.baseUrl + '/api/drugs/delete/' + id , {});
    }
    addDrug(data){
        return this.http.post(this.baseUrl + '/api/drugs/add' ,data);
    }
}
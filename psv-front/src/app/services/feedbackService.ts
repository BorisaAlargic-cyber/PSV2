import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class FeedBackService
{
    baseUrl = 'https://localhost:44308';

    constructor(private http: HttpClient) { }

    addFeedback(data) {

        return this.http.post(this.baseUrl + '/api/feedbacks', data);
    }

    getAllFeedback() {
        return this.http.get(this.baseUrl + '/api/feedbacks/all');

    }

    getPublishedFeedback () {
        return this.http.get(this.baseUrl + '/api/feedbacks/all-pubished');

    }

    putFeedback(id) {
        return this.http.put(this.baseUrl + '/api/feedbacks/' + id, {});
    }

    dontPublish(id){
        return this.http.put(this.baseUrl + '/api/feedbacks/dontPublish/' + id , {});
    }
}
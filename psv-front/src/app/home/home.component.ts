import { Component, OnInit } from '@angular/core';
import { Feedback } from '../feedback/feedback.component';
import { FeedBackService } from '../services/feedbackService';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  displayedColumns: string[] = ['comment'];
  elements;

  constructor(private feedbackService : FeedBackService) { }

  ngOnInit(): void {

    this.elements = [];

    this.feedbackService.getPublishedFeedback().subscribe(result =>{

      console.log(result);

      this.elements = result['entities'];
    })
  }

}

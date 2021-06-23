import { Component, OnInit } from '@angular/core';
import { FeedBackService } from '../services/feedbackService';

export interface Feedback {
  user: string,
  comment: string
}

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.scss']
})
export class FeedbackComponent implements OnInit {

  elements: Feedback[] = []
  displayedColumns: string[] = ['user', 'comment' , 'published']



  constructor(private feedbackService: FeedBackService) { }

  ngOnInit(): void {
    this.feedbackService.getAllFeedback().subscribe(data => {
      this.elements = data['entities'];
      console.log(data);
      
    });
  }
  putFeedback(event,element){
    this.feedbackService.putFeedback(element.id).subscribe(data =>{
      this.ngOnInit();
    })
  }
  
  dontPublish(event,element){
    this.feedbackService.dontPublish(element.id).subscribe(data =>{
      this.ngOnInit();
    })
  }

    
  }



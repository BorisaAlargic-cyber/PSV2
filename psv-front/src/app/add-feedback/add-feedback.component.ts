import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { FeedBackService } from '../services/feedbackService';

@Component({
  selector: 'app-add-feedback',
  templateUrl: './add-feedback.component.html',
  styleUrls: ['./add-feedback.component.scss']
})
export class AddFeedbackComponent implements OnInit {

  addFeedbackForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private feedbackService: FeedBackService, private router: Router) { }

  ngOnInit(): void {
    this.addFeedbackForm = this.formBuilder.group({
      comment: [null, Validators.required]
    });
  }

  submit() {
    
    if (!this.addFeedbackForm.valid) {
      return;
    }

    this.feedbackService.addFeedback(this.addFeedbackForm.value).subscribe(data => {
      
      this.router.navigate(['/feedback']);
    });

    
  }
}

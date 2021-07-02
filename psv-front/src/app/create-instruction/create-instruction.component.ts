import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { threadId } from 'worker_threads';
import { InstructionService } from '../services/instructionService';

@Component({
  selector: 'app-create-instruction',
  templateUrl: './create-instruction.component.html',
  styleUrls: ['./create-instruction.component.scss']
})
export class CreateInstructionComponent implements OnInit {

  instructionForm: FormGroup;
  id: string;

  constructor(private formBuilder: FormBuilder,
    private router: Router, private activatedRoute: ActivatedRoute, private instrctionService: InstructionService) { }

  ngOnInit(): void {
    this.instructionForm = this.formBuilder.group({
      speciality: [null, Validators.required]
    });

    this.activatedRoute.queryParams
      .subscribe(params => {
        this.id = params['id'];
      }
      );
  }

  submit() {

    if (!this.instructionForm.valid) {
      return;
    }

    this.instrctionService.createInstruction({
      patient: { id: parseInt(this.id) },
      speciality: this.instructionForm.value.speciality
    }).subscribe((data) => {
      this.router.navigate(['/apointment-list']);
    });
  }

}

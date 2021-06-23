import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DrugService } from '../services/drugService';

@Component({
  selector: 'app-add-drug',
  templateUrl: './add-drug.component.html',
  styleUrls: ['./add-drug.component.scss']
})
export class AddDrugComponent implements OnInit {

  addDrugForm : FormGroup;

  constructor(private formBuilder: FormBuilder, private drugService: DrugService, private router: Router) { }

  ngOnInit(): void {
    this.addDrugForm = this.formBuilder.group({
      name: [null, Validators.required],
      quantity: [null, Validators.required]
    });
  }

  submit() {
    
    if (!this.addDrugForm.valid) {
      return;
    }

    this.drugService.addDrug({
      name: this.addDrugForm.value.name,
      quantity: parseInt(this.addDrugForm.value.quantity)
    }).subscribe(data => {
      
      this.router.navigate(['/drugs']);
    });

    
  }

}

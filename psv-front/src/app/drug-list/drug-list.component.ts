import { Component, OnInit } from '@angular/core';
import { element } from 'protractor';
import { DrugService } from '../services/drugService';

export interface Drug{
  id: number,
  name: string,
}

@Component({
  selector: 'app-drug-list',
  templateUrl: './drug-list.component.html',
  styleUrls: ['./drug-list.component.scss']
})
export class DrugListComponent implements OnInit {

  elements: Drug[] = []
  displayedColumns: string[] = ['Id', 'Name' , 'Remove']

  constructor(private drugService: DrugService) { }

  ngOnInit(): void {
    this.drugService.getAllDrugs().subscribe(data => {
      this.elements = data['entities'];
      console.log(data);
  });
}

  deleteDrug(event,element){
    this.drugService.deleteDrug(element.id).subscribe(data =>{
      this.ngOnInit();
    })

  }

}

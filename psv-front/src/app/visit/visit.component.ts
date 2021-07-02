import { Component, OnInit } from '@angular/core';
import { VisitService } from '../services/visitService';


export interface Visit {
  apointment: any,
  results: string,
};


@Component({
  selector: 'app-visit',
  templateUrl: './visit.component.html',
  styleUrls: ['./visit.component.scss']
})
export class VisitComponent implements OnInit {

  elements: Visit[] = []
  displayedColumns: string[] = ['doctor', 'patient', 'date', 'results']

  constructor(private visitService: VisitService) { }

  ngOnInit(): void {
    this.visitService.getAllVists().subscribe(data => {
      this.elements = data['entities'];
    });
  }
}

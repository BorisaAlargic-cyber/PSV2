import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/userService';


export interface User {
  firstName: string,
  lastName: string,
  email : string,
};


@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {

  elements: User[] = []
  displayedColumns: string[] = ['firstName', 'lastName' , 'email' , 'block']



  constructor(private userService : UserService) { }

  ngOnInit(): void {
    this.userService.getAllUsers().subscribe(data => {
      console.log(data)
      this.elements = data['entities'];
      console.log(data);
    });

  }

  block(event, element) {

    this.userService.blockUser(element.email).subscribe(data => {
      this.ngOnInit();
    });
  }

  unBlock(event, element){
    this.userService.unBlockUser(element.email).subscribe(data =>{
      this.ngOnInit();
    })
  }

}

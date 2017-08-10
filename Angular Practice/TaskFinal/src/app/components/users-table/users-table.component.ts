import { Component, OnInit } from '@angular/core';
import { UserService } from "../../services/user.service";

@Component({
  selector: 'app-users-table',
  templateUrl: './users-table.component.html',
  styleUrls: ['./users-table.component.css']
})
export class UsersTableComponent implements OnInit {

  users : user[];
  constructor( private userService:UserService) { }

  ngOnInit() {
    this.userService.getUsers().subscribe(data => {
      console.log(data);
      this.users = data;
    });
  }

}

interface user {
  Id : number;
  FirstName : string;
  LastName : string;
  Gender : string;
  Mobile : string;
}

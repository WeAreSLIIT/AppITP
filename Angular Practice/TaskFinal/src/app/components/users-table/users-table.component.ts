import { Component, OnInit } from '@angular/core';
import { UserService } from "../../services/user.service";
import { Observable } from "rxjs/Observable";
import 'rxjs/Rx';
import { User } from "./../../interfaces/user";

@Component({
  selector: 'app-users-table',
  templateUrl: './users-table.component.html',
  styleUrls: ['./users-table.component.css']
})
export class UsersTableComponent implements OnInit {

  users : User[];
  constructor( private userService:UserService) { }

  ngOnInit() {
    Observable.interval(5000).subscribe(x => {
        this.userService.getUsers().subscribe(data => {
        this.users = data;
    });
    });
 
  }

  onClickDelete(index){
    this.userService.deleteUser(this.users[index].Id).subscribe(data=>{
      console.log(data);
    });
  }

  onClickEdit(index){
    this.userService.setSeletetedUser(this.users[index]);
  }

}


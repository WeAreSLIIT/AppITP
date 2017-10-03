import { Component, OnInit } from '@angular/core';
import { UserService } from "./../../services/user.service";
import { User } from "./../../interfaces/user";
@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent implements OnInit {

  user = {
    FirstName :'',
    LastName  :'',
    Gender    :'',
    Mobile    : ''
  } ;

  selectedUser : User ;

  constructor(private userService:UserService) { }

  ngOnInit() {
    this.user = this.userService.getSelectedUser();
  }

  onSubmit(){
    const user = {
      FirstName : this.user.FirstName,
      LastName  : this.user.LastName,
      Gender    : this.user.Gender,
      Mobile    : this.user.Mobile
    }
    console.log(user);
    this.userService.addUser(user).subscribe(data=>{
      console.log(data);
    });
  }
}

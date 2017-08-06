import { Component, OnInit } from '@angular/core';
import { DataService } from './../data.service';
@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

	users : user[];

  constructor( private dataService:DataService) { }

  ngOnInit() {

  	this.dataService.getUsers().subscribe(data => {
  		this.users = data;
  	});
  }

}

interface user {
	name: string;
	website : string;
}

import { Injectable } from '@angular/core';
import { Http,Headers } from "@angular/http";
import 'rxjs/add/operator/map';

@Injectable()
export class UserService {

  constructor(private http:Http) { }

  getUsers(){
    return this.http.get('http://localhost:5556/api/user/')
      .map( res => res.json());
  }
  
  
  
  getUserById(id){
    return this.http.get('http://localhost:5556/api/user/' + id)
    .map(res => res.json());
  }

  addUser(user){
    return this.http.post('http://localhost:5556/api/user/',user)
    .map(res => res.json());
  }

  updateUser(id,user){
    return this.http.put('http://localhost:5556/api/user/' + id,user)
    .map(res => res.json());
    ;
  }

  deleteUser(id){
    return this.http.delete('http://localhost:5556/api/user/' + id)
    .map(res => res.json());
  }
}
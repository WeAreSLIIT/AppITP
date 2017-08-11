import { Injectable } from '@angular/core';
import { Http,Headers } from "@angular/http";
import 'rxjs/add/operator/map';

@Injectable()
export class UserService {

  url = 'http://localhost:5556/api/user/';
  constructor(private http:Http) { }

  getUsers(){
    return this.http.get(this.url)
      .map( res => res.json());
  }
  
  
  
  getUserById(id){
    return this.http.get(this.url + id)
    .map(res => res.json());
  }

  addUser(user){
    return this.http.post(this.url,user)
    .map(res => res.json());
  }

  updateUser(id,user){
    return this.http.put(this.url + id,user)
    .map(res => res.json());
    ;
  }

  deleteUser(id){
    return this.http.delete(this.url + id)
    .map(res => res.json());
  }
}
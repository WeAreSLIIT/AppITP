import { Injectable } from '@angular/core';
import { Http , Headers} from '@angular/http';
import 'rxjs/add/operator/map';


@Injectable()
export class ProductsService {

  constructor(
  	private http:Http 
  	) { }

  getProducts(){
  	return this.http.get('http://localhost:5556/api/product').map(res => res.json());
  }
}

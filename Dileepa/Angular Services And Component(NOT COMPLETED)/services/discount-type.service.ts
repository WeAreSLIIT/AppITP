import { Injectable } from '@angular/core';
import { Http , Headers} from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class DiscountTypeService {

  constructor(
    private http: Http) { }

  getDiscountTypes()
  {
    return this.http.get('http://localhost:5556/api/DiscountType').map(res => res.json());
  }
  addDiscountTypes(discount)
  {
    return this.http.post('http://localhost:5556/api/DiscountType', discount).map(res => res.json());
  }

  deleteDiscountTypes(id)
  {
    return this.http.delete('http://localhost:5556/api/DiscountType/' + id).map(res => res.json());
  }
  updateDiscountTypes(discount, id) {
    return this.http.put('http://localhost:5556/api/DiscountType/'+id, discount).map(res => res.json());
  }
}

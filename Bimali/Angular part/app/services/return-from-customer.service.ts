import { Injectable } from '@angular/core';
import { Http , Headers} from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class ReturnFromCustomerService {

  constructor(private http: Http) { }
    getReturnDetails()
    // tslint:disable-next-line:one-line
    {
      return this.http.get('http://localhost:5556/api/Return').map(res => res.json());
    }
    deleteReturns(id) {
      return this.http.delete('http://localhost:5556/api/Return' + id)
      .map(res => res.json());
    }
}

import { Http, Headers } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class DiscountScheduleService {

  constructor(private http: Http) { }

  getAllDiscountSchedules()
  // tslint:disable-next-line:one-line
  {
    return this.http.get('http://localhost:5556/api/DiscountSchedule').map(res => res.json());
  }

  addDiscountSchedule(discount)
  // tslint:disable-next-line:one-line
  {
    return this.http.post('http://localhost:52028/api/DiscountSchedule', discount).map(res => res.json());
  }
}

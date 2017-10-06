import { Http, Headers } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
@Injectable()
export class DiscountScheduleService {

  constructor(private http: Http) { }
  private _url= 'http://localhost:52028/api/discountSchedule';
    // getDiscountSchedules() {
    //   return this.http.get(this._url)
    //     .map( res => res.json());
    // }

    // getDiscountScheduleById(id) {
    //   return this.http.get(this._url + id)
    //   .map(res => res.json());
    // }

    addDiscountSchedule(discountSchedule) {
      return this.http.post(this._url, discountSchedule)
      .map(res => res.json());
    }

    // updateDiscountSchedule(id, discountSchedule) {
    //   return this.http.put(this._url + id, discountSchedule)
    //   .map(res => res.json());

    // }
    deleteDiscountSchedule(id) {
      return this.http.delete(this._url + id)
      .map(res => res.json());
    }

}

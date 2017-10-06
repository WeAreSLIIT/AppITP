import { Http, Headers } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class AddGiftVoucherService {

  constructor(private http: Http) { }

  // getDiscountTypes()
  // {
  //   return this.http.get('http://localhost:5556/api/DiscountType').map(res => res.json());
  // }
  AddGiftVoucher(voucher)
  {
    return this.http.post('http://localhost:5556/api/GiftVoucherType', voucher).map(res => res.json());
  }

  // deleteDiscountTypes(id)
  // {
  //   return this.http.delete('http://localhost:5556/api/DiscountType/' + id).map(res => res.json());
  // }
}


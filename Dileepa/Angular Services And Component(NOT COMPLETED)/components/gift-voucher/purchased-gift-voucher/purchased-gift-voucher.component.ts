import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-purchased-gift-voucher',
  templateUrl: './purchased-gift-voucher.component.html',
  styleUrls: ['./purchased-gift-voucher.component.css']
})
export class PurchasedGiftVoucherComponent implements OnInit {
// purchases: Purchase[];
  constructor() { }

  ngOnInit() {
  }

}
// interface Purchase{
//   customerName: string;
//   email:string;
//   phone	
//   voucherAmount	
//   sku	
//   status
// }
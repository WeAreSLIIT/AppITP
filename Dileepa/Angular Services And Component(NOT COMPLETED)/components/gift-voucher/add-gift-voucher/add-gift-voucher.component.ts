import { AddGiftVoucherService } from '../../../services/add-gift-voucher.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-gift-voucher',
  templateUrl: './add-gift-voucher.component.html',
  styleUrls: ['./add-gift-voucher.component.css']
})
export class AddGiftVoucherComponent implements OnInit {


  // addVouchers:AddVoucher[];

  constructor(private addGiftVoucherService: AddGiftVoucherService) { }

  ngOnInit() {
  }

}
// interface AddVoucher
// {

// }

import { ReturnFromCustomerService } from '../../../services/return-from-customer.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-return-from-customer',
  templateUrl: './return-from-customer.component.html',
  styleUrls: ['./return-from-customer.component.css']
})
export class ReturnFromCustomerComponent implements OnInit {
returns: Return[];
  constructor(private returnFromCustomerService: ReturnFromCustomerService) { }

  ngOnInit() {
    this.returnFromCustomerService.getReturnDetails().subscribe(data => {
      this.returns = data;
      console.log(this.returns);
    });
  }
  onClickDelete(index)  {
    this.returnFromCustomerService.deleteReturns(this.returns[index].ReturnStockID).subscribe(data => {
      console.log(data);
    });
  }
}
interface Return {
        ReturnStockID: number;
        ReturnStockCode: string;
        ReturnCause: string;
        ReturnQty: number;
        Replacement: string;
        ReturnedToSupplier: string;
}

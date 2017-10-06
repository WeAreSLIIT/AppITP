import { any } from 'codelyzer/util/function';
import { StocksService } from '../../../services/stocks.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-stock',
  templateUrl: './add-stock.component.html',
  styleUrls: ['./add-stock.component.css']
})
export class AddStockComponent implements OnInit {
  stock: any= {};
   stocks: Stock[]=[];
   isNewForm= false;
   discountForm=false;
  constructor(private stocksService: StocksService) { }

  ngOnInit() {
  }

  // add Stock
  addStocks(stock: Stock) {
      // if (this.isNewForm) {
        this.stocksService.addNewStocks(stock).subscribe(data => {
          console.log(data);
        });
        this.stocks.push(stock);
      }
      // tslint:disable-next-line:one-line
      // else{

      // }
      // this.discountForm= false;
    //   this.stocksService.addStocks(stock).subscribe(data => {
    //    console.log(data);
    //  });
    //   this.stocks.push(stock);

}



interface Stock {
  StockID: number;
  PublicStockID: string;
  PublicItemCode: string;
  ItemName: string;
  ItemCategory: string;
  PurchaseOrder: string;
  UoM: string;
  InitQty: number;
  PresentQty: number;
  WholeSaleValue: number;
  UnitPrice: number;
  GRNnum: string;
  StockStatus: number;
  Status: string;
}

import { StocksService } from '../../../services/stocks.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-view-stocks',
  templateUrl: './view-stocks.component.html',
  styleUrls: ['./view-stocks.component.css']
})
export class ViewStocksComponent implements OnInit {
  stocks: Stock[];
  constructor(private stocksService: StocksService) { }

  ngOnInit() {
    this.stocksService.getAllStocks().subscribe(data => {
      this.stocks = data;
      console.log(this.stocks);
    });
  }
  onClickDelete(index) {
      this.stocksService.removeStocks(this.stocks[index].StockID).subscribe(data => {
        console.log(data);
      });
      this.stocks.splice(index, 1);
  }
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

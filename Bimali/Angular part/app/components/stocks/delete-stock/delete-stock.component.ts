import { StocksService } from '../../../services/stocks.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-delete-stock',
  templateUrl: './delete-stock.component.html',
  styleUrls: ['./delete-stock.component.css']
})
export class DeleteStockComponent implements OnInit {

    stock: any= {};
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


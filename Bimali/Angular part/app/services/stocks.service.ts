import { Injectable } from '@angular/core';
import { Http , Headers} from '@angular/http';
import 'rxjs/add/operator/map';


@Injectable()
export class StocksService {

  constructor( private http: Http) { }

  getAllStocks() {
    return this.http.get('http://localhost:5556/api/Stock/Get').map(res => res.json());
  }

  getStock(stockId) {
    return this.http.get('http://localhost:5556/api/Stock/GetStock/' + stockId).map(res => res.json());
  }

  addNewStocks(stock) {
    return this.http.post('http://localhost:5556/api/Stock', stock).map(res => res.json());
  }

  searchStockByItem(itemId) {
    return this.http.get('http://localhost:5556/api/Stock/Search/' + itemId).map(res => res.json());
  }

  removeStocks(Id) {
    return this.http.delete('http://localhost:5556/api/Stock/' + Id).map(res => res.json());
  }

  updateStockQty(quantity, stock) {
    return this.http.put('http://localhost:5556/api/Stock/IssueGoods', quantity, stock );
  }
}

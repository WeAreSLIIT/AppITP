import { Injectable } from '@angular/core';
import { Http , Headers} from '@angular/http';
import 'rxjs/add/operator/map';


@Injectable()
export class CategoriesService  {

  constructor(
  	private http:Http 
  	) { }

  getAllCategories()
  {
  	return this.http.get('http://localhost:5556/api/Category').map(res => res.json());
  }
  
  addCategories(category)
  {
    return this.http.post('http://localhost:5556/api/Category',category).map(res => res.json());
  }

  removeCategories(categoryId)
  {
    return this.http.delete('http://localhost:5556/api/Category/'+categoryId).map(res => res.json());
  }

  getAllSubCategories()
  {
    return this.http.get('http://localhost:5556/api/SubCategory').map(res => res.json());
  }

  getSubCategory(categoryId)
  {
    return this.http.get('http://localhost:5556/api/SubCategory/'+categoryId).map(res => res.json());
  }

  addSubCategories(subCategory)
  {
    return this.http.post('http://localhost:5556/api/SubCategory',subCategory).map(res => res.json());
  }

  removeSubCategories(subCategoryId)
  {
    return this.http.delete('http://localhost:5556/api/SubCategory/'+subCategoryId).map(res => res.json());
  }
}

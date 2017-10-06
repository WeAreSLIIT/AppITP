import { any } from 'codelyzer/util/function';
import { DiscountTypeService } from '../../../services/discount-type.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-discount-types',
  templateUrl: './discount-types.component.html',
  styleUrls: ['./discount-types.component.css']
})
export class DiscountTypesComponent implements OnInit {

  discountTypes: DiscountType[];
  discountForm= false;
  isNewForm= false;
  newDiscount: any= {};

  constructor(private dicountTypeService: DiscountTypeService) { }
// get method
  ngOnInit() {
    this.dicountTypeService.getDiscountTypes().subscribe(data =>  {
      this.discountTypes = data;
      console.log(this.discountTypes);
    });

  }
// delete
  onClickDelete(index) {
    this.dicountTypeService.deleteDiscountTypes(this.discountTypes[index].DiscountTypeId).subscribe(data => {
      console.log(data);
    });
    this.discountTypes.splice(index, 1);
}
// add discount
  saveDiscount(type: DiscountType)
  {
      if(this.isNewForm)
      {
        this.dicountTypeService.addDiscountTypes(type).subscribe(data=>{
          console.log(data);
        });
        this.discountTypes.push(type);
      }
      // tslint:disable-next-line:one-line
      else{
        this.dicountTypeService.updateDiscountTypes(type, type.DiscountTypeId).subscribe(data=>{
          console.log(data);
        });
      }
      this.discountForm = false;
  }

 // edit form 
  showEditForm(type: DiscountType )
  {
    if (!type)
    {
      this.discountForm = false;
      return;
    }
    this.discountForm = true;
    this.isNewForm = false;
    this.newDiscount = type;
  }
 
  showAddDiscountForm()
  {
    if(this.discountTypes.length)
    {
      this.newDiscount = {};
    }
    this.discountForm = true;
    this.isNewForm = true;
  }
}

interface DiscountType {
    DiscountTypeId: number;
    DiscountTypePublicId: string;
    DiscountTypeName: string;
    DiscountTimeSpan: number;
    DiscountTypeTax: number;

}

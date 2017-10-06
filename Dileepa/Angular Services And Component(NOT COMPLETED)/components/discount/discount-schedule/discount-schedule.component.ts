import { DiscountScheduleService } from '../../../services/discount-schedule.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-discount-schedule',
  templateUrl: './discount-schedule.component.html',
  styleUrls: ['./discount-schedule.component.css']
})
export class DiscountScheduleComponent implements OnInit {

  // discountMethods= [
  //   {id: 1, name : 'Fixed' },
  //   {id: 2, name : 'Percentage'},
  // ];

  discountSchedules: DiscountSchedule[];
  newSchedule: any= {};
  constructor(private discountScheduleService: DiscountScheduleService) { }

  ngOnInit() {
    this.discountScheduleService.getAllDiscountSchedules().subscribe(data =>  {
      this.discountSchedules = data;
      console.log(this.discountSchedules);
    });

  }
//   onClickDelete(index) {
//     this.discountScheduleService.deleteDiscountTypes(this.discountTypes[index].DiscountTypeId).subscribe(data => {
//       console.log(data);
//     });
//     this.discountTypes.splice(index, 1);
// }


  // addSchedule()
  // // tslint:disable-next-line:one-line
  // {
  //   const DiscountSchedule = {
  //     ItemCode: this.itemCode,
  //     OriginalPrice: this.originalPrice,
  //     DiscountType : this.discountTypes,
  //     PriceWithDiscount : this.priceAfterDiscount,
  //     From: this.from,
  //     To: this.to
  //   };
  //   this.discountScheduleService.addDiscountSchedule(DiscountSchedule).subscribe(data => {
  //     console.log(data);
  //   });
  // }
}
// interface DiscountType {
//   discountTypeName: string;
// }
interface DiscountSchedule {
  DiscountSheduleId: number;
  DiscountTypeId: number;
  DiscountType: string;
  DiscountShedulePublicId: string;
  DiscountSheduleItemCode: string;
  OriginalPrice: number;
  PriceWithDiscount: number;
  DiscountSheduleFrom: number;
  DiscountSheduleTo: number;
  DiscountAmount: number;
  Method: number;
  DiscountMethod: number;
}

import { NgForm } from '@angular/forms/src/directives';
import { Component, OnInit } from '@angular/core';
import { DiscountScheduleService } from '../../../services/discount/discount-schedule/discount-schedule.service';

@Component({
  selector: 'app-discount-schedule',
  templateUrl: './discount-schedule.component.html',
  styleUrls: ['./discount-schedule.component.css'],

})
export class DiscountScheduleComponent implements OnInit {

  constructor(private discountScheduleService: DiscountScheduleService) { }

  ngOnInit() {
  }
  onSubmit(form: NgForm)
  // tslint:disable-next-line:one-line
  {

  }
}

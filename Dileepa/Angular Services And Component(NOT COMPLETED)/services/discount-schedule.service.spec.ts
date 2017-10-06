import { TestBed, inject } from '@angular/core/testing';

import { DiscountScheduleService } from './discount-schedule.service';

describe('DiscountScheduleService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DiscountScheduleService]
    });
  });

  it('should be created', inject([DiscountScheduleService], (service: DiscountScheduleService) => {
    expect(service).toBeTruthy();
  }));
});

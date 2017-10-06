import { TestBed, inject } from '@angular/core/testing';

import { ReturnFromCustomerService } from './return-from-customer.service';

describe('ReturnFromCustomerService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ReturnFromCustomerService]
    });
  });

  it('should be created', inject([ReturnFromCustomerService], (service: ReturnFromCustomerService) => {
    expect(service).toBeTruthy();
  }));
});

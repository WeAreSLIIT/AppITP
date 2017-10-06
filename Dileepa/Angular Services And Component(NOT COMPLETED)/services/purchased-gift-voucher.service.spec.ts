import { TestBed, inject } from '@angular/core/testing';

import { PurchasedGiftVoucherService } from './purchased-gift-voucher.service';

describe('PurchasedGiftVoucherService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PurchasedGiftVoucherService]
    });
  });

  it('should be created', inject([PurchasedGiftVoucherService], (service: PurchasedGiftVoucherService) => {
    expect(service).toBeTruthy();
  }));
});

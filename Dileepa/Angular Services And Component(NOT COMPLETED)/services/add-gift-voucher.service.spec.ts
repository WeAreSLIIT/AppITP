import { TestBed, inject } from '@angular/core/testing';

import { AddGiftVoucherService } from './add-gift-voucher.service';

describe('AddGiftVoucherService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AddGiftVoucherService]
    });
  });

  it('should be created', inject([AddGiftVoucherService], (service: AddGiftVoucherService) => {
    expect(service).toBeTruthy();
  }));
});

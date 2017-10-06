import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchasedGiftVoucherComponent } from './purchased-gift-voucher.component';

describe('PurchasedGiftVoucherComponent', () => {
  let component: PurchasedGiftVoucherComponent;
  let fixture: ComponentFixture<PurchasedGiftVoucherComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PurchasedGiftVoucherComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchasedGiftVoucherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

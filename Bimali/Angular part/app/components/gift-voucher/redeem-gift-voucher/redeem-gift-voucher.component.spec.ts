import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RedeemGiftVoucherComponent } from './redeem-gift-voucher.component';

describe('RedeemGiftVoucherComponent', () => {
  let component: RedeemGiftVoucherComponent;
  let fixture: ComponentFixture<RedeemGiftVoucherComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RedeemGiftVoucherComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RedeemGiftVoucherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

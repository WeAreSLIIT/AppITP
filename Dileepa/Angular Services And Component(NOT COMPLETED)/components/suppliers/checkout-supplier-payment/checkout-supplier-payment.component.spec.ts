import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckoutSupplierPaymentComponent } from './checkout-supplier-payment.component';

describe('CheckoutSupplierPaymentComponent', () => {
  let component: CheckoutSupplierPaymentComponent;
  let fixture: ComponentFixture<CheckoutSupplierPaymentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CheckoutSupplierPaymentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CheckoutSupplierPaymentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

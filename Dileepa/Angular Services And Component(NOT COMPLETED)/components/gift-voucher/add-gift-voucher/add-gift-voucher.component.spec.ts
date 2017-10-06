import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddGiftVoucherComponent } from './add-gift-voucher.component';

describe('AddGiftVoucherComponent', () => {
  let component: AddGiftVoucherComponent;
  let fixture: ComponentFixture<AddGiftVoucherComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddGiftVoucherComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddGiftVoucherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewGiftVoucherComponent } from './view-gift-voucher.component';

describe('ViewGiftVoucherComponent', () => {
  let component: ViewGiftVoucherComponent;
  let fixture: ComponentFixture<ViewGiftVoucherComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewGiftVoucherComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewGiftVoucherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

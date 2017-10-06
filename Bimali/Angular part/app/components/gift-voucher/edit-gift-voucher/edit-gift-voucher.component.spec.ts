import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditGiftVoucherComponent } from './edit-gift-voucher.component';

describe('EditGiftVoucherComponent', () => {
  let component: EditGiftVoucherComponent;
  let fixture: ComponentFixture<EditGiftVoucherComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditGiftVoucherComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditGiftVoucherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

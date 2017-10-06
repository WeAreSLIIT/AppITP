import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PaySupplierComponent } from './pay-supplier.component';

describe('PaySupplierComponent', () => {
  let component: PaySupplierComponent;
  let fixture: ComponentFixture<PaySupplierComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PaySupplierComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PaySupplierComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

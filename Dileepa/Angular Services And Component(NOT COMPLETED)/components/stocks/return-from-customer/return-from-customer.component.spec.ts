import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReturnFromCustomerComponent } from './return-from-customer.component';

describe('ReturnFromCustomerComponent', () => {
  let component: ReturnFromCustomerComponent;
  let fixture: ComponentFixture<ReturnFromCustomerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReturnFromCustomerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReturnFromCustomerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

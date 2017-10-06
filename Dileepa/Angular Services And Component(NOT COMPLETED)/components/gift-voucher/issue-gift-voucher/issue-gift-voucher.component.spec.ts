import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IssueGiftVoucherComponent } from './issue-gift-voucher.component';

describe('IssueGiftVoucherComponent', () => {
  let component: IssueGiftVoucherComponent;
  let fixture: ComponentFixture<IssueGiftVoucherComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IssueGiftVoucherComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IssueGiftVoucherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

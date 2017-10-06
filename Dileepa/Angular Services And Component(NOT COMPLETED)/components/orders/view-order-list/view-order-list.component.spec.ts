import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewOrderListComponent } from './view-order-list.component';

describe('ViewOrderListComponent', () => {
  let component: ViewOrderListComponent;
  let fixture: ComponentFixture<ViewOrderListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewOrderListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewOrderListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

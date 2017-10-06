import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TransOutStockComponent } from './trans-out-stock.component';

describe('TransOutStockComponent', () => {
  let component: TransOutStockComponent;
  let fixture: ComponentFixture<TransOutStockComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TransOutStockComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TransOutStockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

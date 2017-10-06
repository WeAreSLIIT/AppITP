import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TransInStockComponent } from './trans-in-stock.component';

describe('TransInStockComponent', () => {
  let component: TransInStockComponent;
  let fixture: ComponentFixture<TransInStockComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TransInStockComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TransInStockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

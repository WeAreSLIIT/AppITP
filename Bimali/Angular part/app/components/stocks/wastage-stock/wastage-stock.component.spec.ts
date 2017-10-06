import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WastageStockComponent } from './wastage-stock.component';

describe('WastageStockComponent', () => {
  let component: WastageStockComponent;
  let fixture: ComponentFixture<WastageStockComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WastageStockComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WastageStockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecountTransactionComponent } from './recount-transaction.component';

describe('RecountTransactionComponent', () => {
  let component: RecountTransactionComponent;
  let fixture: ComponentFixture<RecountTransactionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecountTransactionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecountTransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

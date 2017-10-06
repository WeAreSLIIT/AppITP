import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DiscountScheduleComponent } from './discount-schedule.component';

describe('DiscountScheduleComponent', () => {
  let component: DiscountScheduleComponent;
  let fixture: ComponentFixture<DiscountScheduleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DiscountScheduleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DiscountScheduleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

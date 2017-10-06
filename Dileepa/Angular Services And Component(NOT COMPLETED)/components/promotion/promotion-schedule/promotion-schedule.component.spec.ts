import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PromotionScheduleComponent } from './promotion-schedule.component';

describe('PromotionScheduleComponent', () => {
  let component: PromotionScheduleComponent;
  let fixture: ComponentFixture<PromotionScheduleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PromotionScheduleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PromotionScheduleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

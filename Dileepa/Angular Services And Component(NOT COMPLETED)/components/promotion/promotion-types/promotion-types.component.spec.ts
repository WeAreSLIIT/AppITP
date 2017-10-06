import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PromotionTypesComponent } from './promotion-types.component';

describe('PromotionTypesComponent', () => {
  let component: PromotionTypesComponent;
  let fixture: ComponentFixture<PromotionTypesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PromotionTypesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PromotionTypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewProductsSectionComponent } from './view-products-section.component';

describe('ViewProductsSectionComponent', () => {
  let component: ViewProductsSectionComponent;
  let fixture: ComponentFixture<ViewProductsSectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewProductsSectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewProductsSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

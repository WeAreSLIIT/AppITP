import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HandleProductsSectionComponent } from './handle-products-section.component';

describe('HandleProductsSectionComponent', () => {
  let component: HandleProductsSectionComponent;
  let fixture: ComponentFixture<HandleProductsSectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HandleProductsSectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HandleProductsSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

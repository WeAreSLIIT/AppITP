import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HandleCategoryComponent } from './handle-category.component';

describe('HandleCategoryComponent', () => {
  let component: HandleCategoryComponent;
  let fixture: ComponentFixture<HandleCategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HandleCategoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HandleCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HandleProductComponent } from './handle-product.component';

describe('HandleProductComponent', () => {
  let component: HandleProductComponent;
  let fixture: ComponentFixture<HandleProductComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HandleProductComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HandleProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

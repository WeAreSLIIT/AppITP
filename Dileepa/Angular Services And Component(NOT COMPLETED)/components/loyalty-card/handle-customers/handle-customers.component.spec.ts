import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HandleCustomersComponent } from './handle-customers.component';

describe('HandleCustomersComponent', () => {
  let component: HandleCustomersComponent;
  let fixture: ComponentFixture<HandleCustomersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HandleCustomersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HandleCustomersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

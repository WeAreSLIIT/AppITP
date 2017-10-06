import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HandleEmployeesComponent } from './handle-employees.component';

describe('HandleEmployeesComponent', () => {
  let component: HandleEmployeesComponent;
  let fixture: ComponentFixture<HandleEmployeesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HandleEmployeesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HandleEmployeesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

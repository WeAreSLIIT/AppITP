import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLoyaltyProgramComponent } from './add-loyalty-program.component';

describe('AddLoyaltyProgramComponent', () => {
  let component: AddLoyaltyProgramComponent;
  let fixture: ComponentFixture<AddLoyaltyProgramComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddLoyaltyProgramComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddLoyaltyProgramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

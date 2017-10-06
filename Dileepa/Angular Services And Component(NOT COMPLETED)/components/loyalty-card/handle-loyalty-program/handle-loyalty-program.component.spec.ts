import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HandleLoyaltyProgramComponent } from './handle-loyalty-program.component';

describe('HandleLoyaltyProgramComponent', () => {
  let component: HandleLoyaltyProgramComponent;
  let fixture: ComponentFixture<HandleLoyaltyProgramComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HandleLoyaltyProgramComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HandleLoyaltyProgramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

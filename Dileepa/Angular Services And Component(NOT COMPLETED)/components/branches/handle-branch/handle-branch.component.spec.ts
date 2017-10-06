import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HandleBranchComponent } from './handle-branch.component';

describe('HandleBranchComponent', () => {
  let component: HandleBranchComponent;
  let fixture: ComponentFixture<HandleBranchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HandleBranchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HandleBranchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

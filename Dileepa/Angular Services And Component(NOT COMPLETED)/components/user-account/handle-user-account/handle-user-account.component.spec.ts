import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HandleUserAccountComponent } from './handle-user-account.component';

describe('HandleUserAccountComponent', () => {
  let component: HandleUserAccountComponent;
  let fixture: ComponentFixture<HandleUserAccountComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HandleUserAccountComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HandleUserAccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HandleSectionComponent } from './handle-section.component';

describe('HandleSectionComponent', () => {
  let component: HandleSectionComponent;
  let fixture: ComponentFixture<HandleSectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HandleSectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HandleSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IssueGoodsComponent } from './issue-goods.component';

describe('IssueGoodsComponent', () => {
  let component: IssueGoodsComponent;
  let fixture: ComponentFixture<IssueGoodsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IssueGoodsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IssueGoodsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

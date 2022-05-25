import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplaySubjectComponent } from './display-subject.component';

describe('DisplaySubjectComponent', () => {
  let component: DisplaySubjectComponent;
  let fixture: ComponentFixture<DisplaySubjectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplaySubjectComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DisplaySubjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

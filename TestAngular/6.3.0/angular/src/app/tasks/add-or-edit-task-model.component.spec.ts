import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddOrEditTaskModelComponent } from './add-or-edit-task-model.component';

describe('AddOrEditTaskModelComponent', () => {
  let component: AddOrEditTaskModelComponent;
  let fixture: ComponentFixture<AddOrEditTaskModelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddOrEditTaskModelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddOrEditTaskModelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

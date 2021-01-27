import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditContactTypeComponent } from './add-edit-contact-type.component';

describe('AddEditContactTypeComponent', () => {
  let component: AddEditContactTypeComponent;
  let fixture: ComponentFixture<AddEditContactTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditContactTypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditContactTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

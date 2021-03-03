import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnimalFormDialogComponent } from './animal-form-dialog.component';

describe('AnimalFormDialogComponent', () => {
  let component: AnimalFormDialogComponent;
  let fixture: ComponentFixture<AnimalFormDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AnimalFormDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AnimalFormDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

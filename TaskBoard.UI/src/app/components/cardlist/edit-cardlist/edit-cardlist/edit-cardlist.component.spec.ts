import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCardlistComponent } from './edit-cardlist.component';

describe('EditCardlistComponent', () => {
  let component: EditCardlistComponent;
  let fixture: ComponentFixture<EditCardlistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditCardlistComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditCardlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

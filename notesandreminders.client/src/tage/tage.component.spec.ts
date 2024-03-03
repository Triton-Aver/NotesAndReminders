import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TageComponent } from './tage.component';

describe('TageComponent', () => {
  let component: TageComponent;
  let fixture: ComponentFixture<TageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

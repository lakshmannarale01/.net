import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CancelBookingComponent } from './cancel-booking.component';

describe('CancelBookingComponent', () => {
  let component: CancelBookingComponent;
  let fixture: ComponentFixture<CancelBookingComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CancelBookingComponent]
    });
    fixture = TestBed.createComponent(CancelBookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

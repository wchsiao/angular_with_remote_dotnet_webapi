import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EFormServiceRequestTypeStatusComponent } from './eform-service-request-type-status.component';

describe('EformServiceRequestTypeStatusComponent', () => {
  let component: EFormServiceRequestTypeStatusComponent;
  let fixture: ComponentFixture<EFormServiceRequestTypeStatusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EFormServiceRequestTypeStatusComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EFormServiceRequestTypeStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

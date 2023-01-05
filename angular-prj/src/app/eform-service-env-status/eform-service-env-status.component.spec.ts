import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EFormServiceEnvStatusComponent } from './eform-service-env-status.component';

describe('EFormServiceStatusComponent', () => {
  let component: EFormServiceEnvStatusComponent;
  let fixture: ComponentFixture<EFormServiceEnvStatusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EFormServiceEnvStatusComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EFormServiceEnvStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

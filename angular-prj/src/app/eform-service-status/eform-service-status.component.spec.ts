import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EFormServiceStatusComponent } from './eform-service-status.component';

describe('EformServiceStatusComponent', () => {
  let component: EFormServiceStatusComponent;
  let fixture: ComponentFixture<EFormServiceStatusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EFormServiceStatusComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EFormServiceStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

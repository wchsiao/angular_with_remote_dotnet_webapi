import { TestBed } from '@angular/core/testing';

import { EFormServiceEnvStatusService } from './eform-service-env-status.service';

describe('EFormServiceStatusService', () => {
  let service: EFormServiceEnvStatusService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EFormServiceEnvStatusService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

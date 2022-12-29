import { TestBed } from '@angular/core/testing';

import { EFormServiceStatusService } from './eform-service-status.service';

describe('EFormServiceStatusService', () => {
  let service: EFormServiceStatusService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EFormServiceStatusService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

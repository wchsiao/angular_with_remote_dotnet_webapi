import { TestBed } from '@angular/core/testing';

import { EformServiceStatusService } from './eform-service-request-type-status.service';

describe('EformServiceStatusService', () => {
  let service: EformServiceStatusService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EformServiceStatusService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

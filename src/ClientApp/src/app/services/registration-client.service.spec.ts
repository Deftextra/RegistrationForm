import { TestBed } from '@angular/core/testing';

import { RegistrationClientService } from './registration-client.service';

describe('RegistrationClientService', () => {
  let service: RegistrationClientService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RegistrationClientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

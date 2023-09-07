import { TestBed } from '@angular/core/testing';

import { ComprarAccionesService } from './comprar-acciones.service';

describe('ComprarAccionesService', () => {
  let service: ComprarAccionesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ComprarAccionesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

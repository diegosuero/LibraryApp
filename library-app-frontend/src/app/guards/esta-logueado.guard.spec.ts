import { TestBed, async, inject } from '@angular/core/testing';

import { EstaLogueadoGuard } from './esta-logueado.guard';

describe('EstaLogueadoGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EstaLogueadoGuard]
    });
  });

  it('should ...', inject([EstaLogueadoGuard], (guard: EstaLogueadoGuard) => {
    expect(guard).toBeTruthy();
  }));
});

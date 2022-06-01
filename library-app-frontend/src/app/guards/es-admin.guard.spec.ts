import { TestBed, async, inject } from '@angular/core/testing';

import { EsAdminGuard } from './es-admin.guard';

describe('EsAdminGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EsAdminGuard]
    });
  });

  it('should ...', inject([EsAdminGuard], (guard: EsAdminGuard) => {
    expect(guard).toBeTruthy();
  }));
});

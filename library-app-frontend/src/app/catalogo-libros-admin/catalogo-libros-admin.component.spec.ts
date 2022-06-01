import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CatalogoLibrosAdminComponent } from './catalogo-libros-admin.component';

describe('CatalogoLibrosAdminComponent', () => {
  let component: CatalogoLibrosAdminComponent;
  let fixture: ComponentFixture<CatalogoLibrosAdminComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CatalogoLibrosAdminComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CatalogoLibrosAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarUsuariosAtivosComponent } from './listar-usuarios-ativos.component';

describe('ListarUsuariosAtivosComponent', () => {
  let component: ListarUsuariosAtivosComponent;
  let fixture: ComponentFixture<ListarUsuariosAtivosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListarUsuariosAtivosComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListarUsuariosAtivosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

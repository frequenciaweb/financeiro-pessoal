import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-listar-usuarios-ativos',
  templateUrl: './listar-usuarios-ativos.component.html',
  styleUrls: ['./listar-usuarios-ativos.component.css']
})
export class ListarUsuariosAtivosComponent {

    public listaUsuarios = [];

    constructor(private http : HttpClient){

       this.http.get(`${environment.apiUrl}/Usuarios/ListarAtivos`).subscribe((usuarios) =>
       {
          this.listaUsuarios = usuarios as any;
       });
    }

}

import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AlertService } from 'src/app/util/alert/alert.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-usuario-incluir',
  templateUrl: './usuario-incluir.component.html',
  styleUrls: ['./usuario-incluir.component.css']
})
export class UsuarioIncluirComponent {

 constructor(private http : HttpClient, private router: Router,
  public alertService: AlertService){

 }

   public usuario : any = {};


   salvar(){
    this.usuario.EhAdmin = false;
    this.http.post(`${environment.apiUrl}/Usuarios/AutoCadastro`, this.usuario)
    .subscribe(resultado => {
      console.log(resultado)
      this.alertService.success("Cadastro efetuado com sucesso");
      this.router.navigate(["/"]);
    });
    }

}

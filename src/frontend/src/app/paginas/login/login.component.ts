import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/environments/environment.development';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

public logon = {login: "", senha: ""};

constructor(private http : HttpClient){}

logar(){
  this.http.post(`${environment.apiUrl}/Usuarios/Logar`, this.logon)
  .subscribe(resultado => {
    console.log(resultado)
    localStorage.setItem("UsuarioLogado", JSON.stringify(resultado));
  },
  (except) => {
    console.log(except)
     alert(except.error);
  });
  }
}

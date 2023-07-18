import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment.development';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

public logon = {login: "", senha: ""};

constructor(private http : HttpClient, private router: Router){}

logar(){
  this.http.post(`${environment.apiUrl}/Usuarios/Logar`, this.logon)
  .subscribe(resultado => {
    console.log(resultado)
    localStorage.setItem("UsuarioLogado", JSON.stringify(resultado));
    this.router.navigate(["/home"]);
  },
  (except) => {
    console.log(except)
     alert(except.error);
  });
  }
}

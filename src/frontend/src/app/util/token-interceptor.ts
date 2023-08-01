import { HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    var token = "";

    var usuario = localStorage.getItem("UsuarioLogado");
    if (usuario) {
      var usuarioLogado = JSON.parse(usuario);
      if (usuarioLogado.token) {
        token = usuarioLogado.token;
      }
    }

      let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');

    if (token){
      headers = headers.set('Authorization', `Bearer ${token} `);
    }

    const authReq = req.clone({headers});
    return next.handle(authReq);
  }
}

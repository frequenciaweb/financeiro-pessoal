import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateFn, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GuardaRotaService implements CanActivate {

  constructor(private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {

    var usuario = localStorage.getItem("UsuarioLogado");
    if (usuario) {
      var usuarioLogado = JSON.parse(usuario);
      if (usuarioLogado.token) {
        return true;
      }
    }

    this.router.navigate(["/login"]);
    return false;
  }
}

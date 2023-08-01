import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { AlertService } from '../util/alert/alert.service';
import { Router } from '@angular/router';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private alertService: AlertService, private router: Router) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(catchError(error => {

      this.alertService.clear();

      if (error.status >= 0) {
        if (error.status == 400) {
          this.alertService.error(error.error);
        }

        if (error.status == 401) {
           localStorage.setItem("UsuarioLogado", "");
           location.reload();
        }

        if (error.status == 403) {
          this.alertService.error("Você não possuei permissão para acessar este recurso!");
       }

        if (error.status == 500 || error.status == 0) {
          this.alertService.error("Falha ao se comunicar com o servidor, por favor tente novamente mais tarde!");
        }
      }
      return throwError(error);
    }))
  }
}

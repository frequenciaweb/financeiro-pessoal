import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginComponent } from './paginas/login/login.component';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './paginas/home/home.component';
import { GuardaRotaService } from './servicos/guarda.rota.service';
import { SobreComponent } from './paginas/sobre/sobre.component';
import { PoliticaPrivacidadeComponent } from './paginas/politica-privacidade/politica-privacidade.component';
import { AlertModule } from './util/alert/alert.module';
import { ErrorInterceptor } from './util/error-interceptor';
import { ListarUsuariosAtivosComponent } from './paginas/listar-usuarios-ativos/listar-usuarios-ativos.component';
import { TokenInterceptor } from './util/token-interceptor';
import { UsuarioIncluirComponent } from './paginas/usuario-incluir/usuario-incluir.component';
import { DashboardComponent } from './paginas/dashboard/dashboard.component';
import { MenuLateralComponent } from './estrutura/menu-lateral/menu-lateral.component';
import { RodapeComponent } from './estrutura/rodape/rodape.component';
import { MenuSuperiorComponent } from './estrutura/menu-superior/menu-superior.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    SobreComponent,
    PoliticaPrivacidadeComponent,
    ListarUsuariosAtivosComponent,
    UsuarioIncluirComponent,
    DashboardComponent,
    MenuLateralComponent,
    RodapeComponent,
    MenuSuperiorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    HttpClientModule,
    AlertModule,
    FormsModule,
    BrowserAnimationsModule,
    MatSlideToggleModule,
    MatButtonModule,
    MatIconModule,
    MatDividerModule
    ],
  providers: [
    GuardaRotaService,
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi:  true},
    {provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi:  true}],
  bootstrap: [AppComponent]
})
export class AppModule { }

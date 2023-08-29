import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './paginas/login/login.component';
import { HomeComponent } from './paginas/home/home.component';
import { GuardaRotaService } from './servicos/guarda.rota.service';
import { SobreComponent } from './paginas/sobre/sobre.component';
import { PoliticaPrivacidadeComponent } from './paginas/politica-privacidade/politica-privacidade.component';
import { ListarUsuariosAtivosComponent } from './paginas/listar-usuarios-ativos/listar-usuarios-ativos.component';
import { UsuarioIncluirComponent } from './paginas/usuario-incluir/usuario-incluir.component';

const routes: Routes = [
  {path: "login",component: LoginComponent},
  {path: "home", component: HomeComponent, canActivate: [GuardaRotaService]},
  {path: "sobre", component: SobreComponent},
  {path: "politica", component: PoliticaPrivacidadeComponent},
  {path: "listar-usuarios", component: ListarUsuariosAtivosComponent, canActivate: [GuardaRotaService]},
  {path: "cadastre-se", component: UsuarioIncluirComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

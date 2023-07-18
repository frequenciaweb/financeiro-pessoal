import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginComponent } from './paginas/login/login.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './paginas/home/home.component';
import { GuardaRotaService } from './servicos/guarda.rota.service';
import { SobreComponent } from './paginas/sobre/sobre.component';
import { PoliticaPrivacidadeComponent } from './paginas/politica-privacidade/politica-privacidade.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    SobreComponent,
    PoliticaPrivacidadeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [GuardaRotaService],
  bootstrap: [AppComponent]
})
export class AppModule { }

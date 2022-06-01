
import { MaterialComponentsModule } from './material.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {MatButtonModule, MatCheckboxModule, MatSelectModule} from '@angular/material';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatPaginatorModule } from '@angular/material';
import { FormsModule } from '@angular/forms';


import { NotFoundComponent } from './not-found/not-found.component';

import { HttpClientModule, HTTP_INTERCEPTORS  } from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import {MatExpansionModule} from '@angular/material/expansion';
import { RegistrarseComponent } from './registrarse/registrarse.component';
import { AltaLibroComponent } from './alta-libro/alta-libro.component';
import { CatalogoLibrosComponent } from './catalogo-libros/catalogo-libros.component';
import { CatalogoLibrosAdminComponent } from './catalogo-libros-admin/catalogo-libros-admin.component';
import { ReservasActivasComponent } from './reservas-activas/reservas-activas.component';
import { InvitacionComponent } from './invitacion/invitacion.component';

@NgModule({
  declarations: [
    AppComponent,
    NotFoundComponent,
    LoginComponent,
    RegistrarseComponent,
    AltaLibroComponent,
    CatalogoLibrosComponent,
    CatalogoLibrosAdminComponent,
    ReservasActivasComponent,
    InvitacionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialComponentsModule,
    FormsModule,
    MatSelectModule,
    MatExpansionModule,
    HttpClientModule,
    MatPaginatorModule
    
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

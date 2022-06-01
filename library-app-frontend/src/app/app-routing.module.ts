
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { NotFoundComponent } from "./not-found/not-found.component";
import { LoginComponent } from "./login/login.component";
import { RegistrarseComponent } from "./registrarse/registrarse.component";
import { AltaLibroComponent } from "./alta-libro/alta-libro.component";
import { CatalogoLibrosComponent } from "./catalogo-libros/catalogo-libros.component";
import { CatalogoLibrosAdminComponent } from "./catalogo-libros-admin/catalogo-libros-admin.component";
import { ReservasActivasComponent } from "./reservas-activas/reservas-activas.component";
import { InvitacionComponent } from "./invitacion/invitacion.component";
import { EstaLogueadoGuard } from "./guards/esta-logueado.guard";
import { EsAdminGuard } from "./guards/es-admin.guard";

const routes: Routes = [
  { path: "login", component: LoginComponent },
  { path: "registrarse", component: RegistrarseComponent },
  { path: "altaLibro", component: AltaLibroComponent,canActivate: [EstaLogueadoGuard,EsAdminGuard]  },
  { path: "catalogoLibros", component: CatalogoLibrosComponent ,canActivate: [EstaLogueadoGuard] },
  { path: "catalogoLibrosAdm", component: CatalogoLibrosAdminComponent,canActivate: [EstaLogueadoGuard,EsAdminGuard]},
  { path: "reservasActivas", component: ReservasActivasComponent,canActivate: [EstaLogueadoGuard] },
  { path: "invitacion/:id", component: InvitacionComponent },
  { path: "", component: CatalogoLibrosComponent ,canActivate: [EstaLogueadoGuard] },
  { path: "**", component: NotFoundComponent },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}

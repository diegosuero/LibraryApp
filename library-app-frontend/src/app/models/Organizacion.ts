import { Usuario } from "./UsuarioModel";

export class OrganizacionModel {
    name : string;
    Admin : Usuario;
   
  
    constructor(Nombre:string,Admin : Usuario){
        this.name = Nombre;
        this.Admin = Admin;
    }
  }
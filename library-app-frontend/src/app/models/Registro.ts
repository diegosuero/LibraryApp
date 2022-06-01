import { OrganizacionModel } from "./Organizacion";
import { Usuario } from "./UsuarioModel";

export class RegistroModel {
    Name : string;
    Email : string;
    Password : string;
    Organization : OrganizacionModel;
    
  
    constructor(Nombre : string, Email : string,Password : string,Organizacion : OrganizacionModel){
        this.Password = Password;
        this.Name = Nombre;
        this.Email = Email;
        this.Organization = Organizacion;
    }
  }
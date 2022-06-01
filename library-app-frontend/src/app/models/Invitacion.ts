import { Usuario } from "./UsuarioModel";
import { OrganizacionModel } from "./Organizacion";

export class InvitacionModel {
    //ISBN : Number;
    rol : string;
    mail : string;
    organization : OrganizacionModel;
  
    constructor(Rol : string, mail : string,Organization : OrganizacionModel){
        this.rol = Rol;
        this.mail = mail;
        this.organization = Organization;
    }
  }
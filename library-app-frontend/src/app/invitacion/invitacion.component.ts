import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { InvitacionModel } from '../models/Invitacion';
import { Usuario } from '../models/UsuarioModel';
import { InvitacionService } from "./../services/invitacion.service";

@Component({
  selector: 'app-invitacion',
  templateUrl: './invitacion.component.html',
  styleUrls: ['./invitacion.component.css']
})
export class InvitacionComponent implements OnInit {

  constructor(private invitacionLogin: InvitacionService,
    private route: ActivatedRoute) { }

  NombreOrg = "Nombre Org";
  Rol ="Admin";
  Nombre="";
  Email="";
  Password="";
  id :Number;
 

  private sub: any;

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.invitacionLogin.getinvitacion(params['id']).subscribe(
        (data: InvitacionModel) => this.result(data),
        (error: any) => alert(error.error)
      );
      this.id=params['id'];
   });
  }

    cargardatos(){
      this.invitacionLogin.getinvitacion(this.id).subscribe(
        (data: InvitacionModel) => this.result(data),
        (error: any) => alert(error.error)
      );
    }

    public result(invitacion : InvitacionModel):void{
      console.log(invitacion);
      this.NombreOrg=invitacion.organization.name;
      this.Rol=invitacion.rol;
    }

  registrar(): void {
    var usr = new Usuario(null,this.Nombre,this.Email,this.Password,false);
    //console.log(usr);
    this.invitacionLogin.postinvitacion(usr,this.id).subscribe(
      (data: string) => console.log(data),
      (error: any) => alert(error.error)
    );
    this.Nombre="";
    this.Email="";
    this.Password="";
  }

}

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OrganizacionModel } from '../models/Organizacion';
import { RegistroService } from '../services/registro.service';
import { RegistroModel } from "./../models/Registro";

@Component({
  selector: 'app-registrarse',
  templateUrl: './registrarse.component.html',
  styleUrls: ['./registrarse.component.css']
})
export class RegistrarseComponent implements OnInit {

  constructor(
    private router: Router,
    private registroService: RegistroService
    ) { }

  ngOnInit() {
  }
  Mail = "";
  Password = "";
  Nombre = "";
  Organizacion="";

  onKeyMail(event: any) {
    this.Mail = event.target.value ;
  }
  onKeyPassword(event: any) {
    this.Password = event.target.value ;
  }
  onKeyNombre(event: any) {
    this.Nombre = event.target.value ;
  }
  onKeyNombreOrganizacion(event: any) {
    this.Organizacion = event.target.value ;
  }

  registrar(): void {
    //console.log(this.Organizacion + " "+this.Nombre+ " "+this.Mail+ " "+this.Password);
  
    var OrganizacionObj = new OrganizacionModel(this.Organizacion,null);
    const registro = new RegistroModel(
      this.Nombre,this.Mail,this.Password,OrganizacionObj
    );
    console.log(registro);
    this.registroService.postRegistro(registro).subscribe(
      (data: string) =>this.router.navigate(["/login"]),
      (error: any) => alert(error.error)
    );
  }

}

import { Component, OnInit, ViewChild } from '@angular/core';
import { LibroModel } from '../models/Libro';
import { InvitacionModel } from '../models/Invitacion';
import { InvitacionService } from '../services/invitacion.service';
import { OrganizacionModel } from '../models/Organizacion';
import { LibroService } from '../services/libro.service';
import { Router } from '@angular/router';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-catalogo-libros-admin',
  templateUrl: './catalogo-libros-admin.component.html',
  styleUrls: ['./catalogo-libros-admin.component.css']
})


export class CatalogoLibrosAdminComponent implements OnInit {
  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;
  constructor(private invitacinService: InvitacionService, private serivceLibro: LibroService,
    private router: Router) { }

  ngOnInit() {
    this.getLibros();
    this.dataSource.paginator = this.paginator;
    
  }
  

  displayedColumns: string[] = ['Id','ISBN', 'Titulo','Autores','Year','Ejemplares','Activo','Action'];

  dataSource = new MatTableDataSource<any>();
  display:boolean=false;
  selectedLibro;
  isChecked:Boolean = true;
  apikey="";
  resultsLength = 0;



  public selected(libro : LibroModel):void{

    this.selectedLibro=libro;
    this.ISBN=libro.isbn.toString();
    this.Titutlo=libro.title;
    this.Autores=libro.authors;
    this.Year=libro.year;
    this.Ejemplares=libro.count;
    this.Id=libro.id;
    this.isChecked=libro.isActive;
    this.display=true;

  }

  public reservar():void{
    this.display=false;

  }

  filter="";

  applyFilter(...args: []) {
    const filterValue = this.filter;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();

    }
  }

  public crearInvitacion():void{
    var org = new OrganizacionModel(null,null);
    var invitacion : InvitacionModel = new InvitacionModel(this.selectedd,this.Mail,null);
    this.invitacinService.createinvitacion(invitacion).subscribe(
      (data: string) =>console.log(data),
      (error: any) => alert(error.error)
    );
  }
  
  public getLibros():void{
    
    this.serivceLibro.getLibros().subscribe(
      (data: Array<LibroModel>) =>this.response(data),
      (error: any) => alert(error.error)
    );
    this.serivceLibro.getapikey().subscribe(
      (data: string) =>this.respuestaApi(data),
      (error: any) => alert(error.error)
    );
  }

  public respuestaApi(data:string){
    localStorage.setItem("apikey", data);
    this.apikey=data;
  }

  public response(list : Array<LibroModel>):void{
    this.dataSource = new MatTableDataSource(list);
    console.log(list);
  }

  public result(data :string):void{
    console.log(data);
    this.getLibros();
  }
  public actualizarKey():void{
    this.serivceLibro.actualizar().subscribe(
      (data: string) =>this.respuestaApi(data),
      (error: any) => alert(error.error)
    );
  }
  
  public modificar():void{
    this.display=false;
    var libroNuevo = new LibroModel(
      this.ISBN,this.Titutlo,this.Autores,this.Year,this.Ejemplares,this.isChecked
    );
    this.serivceLibro.putLibro(this.Id,libroNuevo).subscribe(
      (data: string) =>this.result(data),
      (error: any) => alert(error.error)
    );
  }
  public borrar(libro : LibroModel):void{
    this.display=false;
    this.serivceLibro.deleteLibro(libro.id).subscribe(
      (data: string) =>this.result(data),
      (error: any) => alert(error.error)
    );
  }



  Titutlo  = "";
  ISBN ="";
  Autores = "";
  Year="";
  Ejemplares:Number;
  selectedd = "Comun";
  Mail = "";
  Id :Number;

  onKeyTitulo(event: any) {
    this.Titutlo = event.target.value ;
  }
  onKeyISBN(event: any) {
    this.ISBN = event.target.value ;
  }
  onKeyAutores(event: any) {
    this.Autores = event.target.value ;
  }
  onKeyYear(event: any) {
    this.Year = event.target.value ;
  }
  onKeyEjemplares(event: any) {
    this.Ejemplares = event.target.value ;
  }

}

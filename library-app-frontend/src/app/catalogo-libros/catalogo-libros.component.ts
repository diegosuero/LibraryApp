import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LibroModel } from '../models/Libro';
import { LibroService } from '../services/libro.service';
import { InvitacionService } from '../services/invitacion.service';
import { ReservaModel } from '../models/Reserva';
import { ReservaService } from '../services/reserva.service';
import { MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-catalogo-libros',
  templateUrl: './catalogo-libros.component.html',
  styleUrls: ['./catalogo-libros.component.css']
})
export class CatalogoLibrosComponent implements OnInit {

  constructor(private invitacinService: InvitacionService,private reservaService: ReservaService, private serivceLibro: LibroService,
    private router: Router) {
    this.minDate = new Date();
    this.getLibros();
   }

  displayedColumns: string[] = ['ISBN', 'Titulo','Autores','Year','Ejemplares','Action'];
  dataSource = new MatTableDataSource<any>();;
  display:boolean=false;
  fecha:Date;
  minDate: Date;
  selectedLibro;

  filter="";

  applyFilter(...args: []) {
    const filterValue = this.filter;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();

    }
  }
  
  public getLibros():void{
    this.serivceLibro.getLibros().subscribe(
      (data: Array<LibroModel>) =>this.response(data),
      (error: any) => alert(error.error)
    );
  }


  public response(list : Array<LibroModel>):void{
    this.dataSource= new MatTableDataSource(list);
    console.log(list);
  }

  public selected(libro : LibroModel):void{
    this.selectedLibro=libro;
    console.log(this.selectedLibro);
    this.display=true;

  }

  public reservar():void{
    this.display=false;
    
    var res = new ReservaModel(this.selectedLibro,this.fecha);
    var dia =this.fecha.getMonth()+1;
    var fech = this.fecha.getFullYear()+"/"+dia+"/"+this.fecha.getDate();
    console.log(fech);
    this.reservaService.postReserva(this.selectedLibro.id,fech).subscribe(
      (data: string) => console.log(data),
      (error: any) => console.log(error.error)
    );

  }

 

  ngOnInit() {
  }

}

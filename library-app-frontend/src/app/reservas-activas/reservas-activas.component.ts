import { Component, OnInit } from '@angular/core';
import { ReservaModel } from '../models/Reserva';
import { ReservaService } from '../services/reserva.service';

@Component({
  selector: 'app-reservas-activas',
  templateUrl: './reservas-activas.component.html',
  styleUrls: ['./reservas-activas.component.css']
})
export class ReservasActivasComponent implements OnInit {

  constructor(private reservaService: ReservaService) { }

  displayedColumns: string[] = ['Titulo','ISBN', 'Fecha'];
  ngOnInit() {
    this.cargar();
  }
  dataSource=[];
  
  public cargar():void{    
    this.reservaService.getReserva().subscribe(
      (data: Array<ReservaModel>) => this.dataSource=data,
      (error: any) => console.log(error.error)
    );

  }

}

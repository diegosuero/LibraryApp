import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LibroModel } from '../models/Libro';
import { LibroService } from '../services/libro.service';

@Component({
  selector: 'app-alta-libro',
  templateUrl: './alta-libro.component.html',
  styleUrls: ['./alta-libro.component.css']
})
export class AltaLibroComponent implements OnInit {

  constructor(private serivceLibro: LibroService,
    private router: Router) { }

  Titutlo = "";
  ISBN = 0;
  Autores = "";
  Year=0;
  Ejemplares=0;

  

  ngOnInit() {
  }
  registrar(): void {
    
    const libro = new LibroModel(
      this.ISBN.toString(),this.Titutlo,this.Autores,this.Year.toString(),this.Ejemplares,true
    );
    console.log(libro);
    this.serivceLibro.postLibro(libro).subscribe(
      (data: string) => console.log(data),
      (error: any) => console.log(error.error)
    );

  }
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

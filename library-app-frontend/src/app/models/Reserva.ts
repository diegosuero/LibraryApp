import { LibroModel } from "./Libro";

export class ReservaModel {
    initDate : Date;
    finalDate : Date;
    book : LibroModel;
   
  
    constructor(Libro : LibroModel,fechaInicio : Date){
        this.initDate = fechaInicio;
        this.book = Libro;
    }
  }
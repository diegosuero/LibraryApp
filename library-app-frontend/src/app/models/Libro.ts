export class LibroModel {
    isbn : String;
    count : Number;
    year : string;
    title: string;
    authors: string;
    isActive: Boolean;
    id : Number;
   
  
    constructor(ISBN:string, Titulo:string,autores:string,Year:string,ejemplares:Number,isActive : Boolean){
        this.title = Titulo;
        this.authors = autores;
        this.isbn = ISBN;
        this.count = ejemplares;
        this.year = Year;
        this.isActive = isActive;
    }
  }
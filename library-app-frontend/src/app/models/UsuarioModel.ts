export class Usuario {
    
    name: string;
    password: string;
    mail: string;
    
   
  
    constructor(id:Int32Array, nombre:string,email:string,contrasena:string,esAdmin: boolean){
        this.mail = email;
        this.name = nombre;
        
        this.password = contrasena;
        
    }
  }
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'LibraryApp';
  constructor(
    private router: Router) {
   }

   isLoggedAndAdmin(): boolean{
    return localStorage.getItem('token')!== null &&localStorage.getItem('esAdmin')== "true";
  }
  isLoggedAndNotAdmin(): boolean{
    return localStorage.getItem('token')!== null &&localStorage.getItem('esAdmin')!== "true";
  }
  isNotLogged(): boolean{
    return localStorage.getItem('token')== null;
  }

  logOut(){
    localStorage.clear();
    this.router.navigate(["login"]);
  }
}

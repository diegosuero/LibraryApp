import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EsAdminGuard implements CanActivate {
  constructor(private router:Router){}
  canActivate(
    
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
     var esAdmin = localStorage.getItem('esAdmin');
     if (esAdmin != null && esAdmin == "true") {
        return true;
     }else{
      this.router.navigate(["/catalogoLibros"]);
      return false;
     }
      return true;
  }
}

import { Injectable } from '@angular/core';
import { Login } from "./../models/login";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { map, tap, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private WEB_API_URL: string = environment.apiUrl;
  constructor(private _httpService: HttpClient) {}

  postLogin(login: Login): Observable<string> {
    const myHeaders = new HttpHeaders();
    myHeaders.append("Accept", "application/text");
    const httpOptions = {
      headers: myHeaders,
    };
    return this._httpService.post<string>(
      this.WEB_API_URL + "Sessions",
      login,
      httpOptions
    );
  }
}

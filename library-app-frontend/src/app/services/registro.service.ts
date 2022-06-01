import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RegistroModel } from '../models/Registro';

@Injectable({
  providedIn: 'root'
})
export class RegistroService {

  constructor(private _httpService: HttpClient) { }
  private WEB_API_URL: string = environment.apiUrl;

  postRegistro(registro: RegistroModel): Observable<string> {
    const myHeaders = new HttpHeaders();
    myHeaders.append("Accept", "application/text");
    
    const httpOptions = {
      headers: myHeaders,
    };
    return this._httpService.post<string>(
      this.WEB_API_URL + "Admin",
      registro,
      httpOptions
    );
  }
}

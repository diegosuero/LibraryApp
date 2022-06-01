import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { InvitacionModel } from '../models/Invitacion';
import { Usuario } from '../models/UsuarioModel';

@Injectable({
  providedIn: 'root'
})
export class InvitacionService {

  constructor(private _httpService: HttpClient) { }
  private WEB_API_URL: string = environment.apiUrl;

  getinvitacion(id : Number): Observable<InvitacionModel> {
    const myHeaders = new HttpHeaders();
    myHeaders.append("Accept", "application/json");
    myHeaders.append('Access-Control-Allow-Headers', 'Content-Type');
    myHeaders.append('Access-Control-Allow-Methods', 'GET');
    myHeaders.append('Access-Control-Allow-Origin', '*');
    const httpOptions = {
      headers: myHeaders,
    };
    return this._httpService.get<InvitacionModel>(
      this.WEB_API_URL + "Invitation/"+ id,
      httpOptions
    );
  }

  postinvitacion(admin: Usuario,id : Number): Observable<string> {
    console.log(admin);
    const myHeaders = new HttpHeaders();//.set("token",localStorage.getItem('token'));
    myHeaders.append("Accept", "application/text");
    myHeaders.append('Access-Control-Allow-Headers', 'Content-Type');
    myHeaders.append('Access-Control-Allow-Methods', 'GET');
    myHeaders.append('Access-Control-Allow-Origin', '*');
    const httpOptions = {
      headers: myHeaders,
    };
    return this._httpService.post<string>(
      this.WEB_API_URL + "Invitation/"+ id,
      admin,
      httpOptions
    );

  }

  createinvitacion(admin: InvitacionModel): Observable<string> {
    const myHeaders = new HttpHeaders().set("token",localStorage.getItem('token'));
    myHeaders.append("Accept", "application/text");
    myHeaders.append('Access-Control-Allow-Headers', 'Content-Type');
    myHeaders.append('Access-Control-Allow-Methods', 'GET');
    myHeaders.append('Access-Control-Allow-Origin', '*');
    const httpOptions = {
      headers: myHeaders,
    };
    return this._httpService.post<string>(
      this.WEB_API_URL + "Invitation",
      admin,
      httpOptions
    );

  }
}

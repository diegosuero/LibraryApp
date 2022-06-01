import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ReservaModel } from '../models/Reserva';

@Injectable({
  providedIn: 'root'
})
export class ReservaService {

  private WEB_API_URL: string = environment.apiUrl;
  private auth = localStorage.getItem("token");
  constructor(private _httpService: HttpClient) {}

  getReserva(): Observable<Array<ReservaModel>> {
    const myHeaders = new HttpHeaders().set("token",localStorage.getItem('token'));
    myHeaders.append("Accept", "application/json");
    const httpOptions = {
      headers: myHeaders,
    };

    return this._httpService.get<Array<ReservaModel>>(
      this.WEB_API_URL + "Reservation" ,
      httpOptions
    );
  }

  postReserva(id: Number,fecha : string): Observable<string> {
    
    const myHeaders = new HttpHeaders().set("token",localStorage.getItem('token'));
    console.log(localStorage.getItem('token'));
    myHeaders.append("Accept", "application/text");

    const httpOptions = {
      headers: myHeaders,
    };
    return this._httpService.post<string>(
      this.WEB_API_URL + "Reservation/"+id +"/"+fecha,
      localStorage.getItem('token'),
      httpOptions
    );

  }

}

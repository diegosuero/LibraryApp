import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LibroModel } from '../models/Libro';

@Injectable({
  providedIn: 'root'
})
export class LibroService {

  constructor(private _httpService: HttpClient) { }
  private WEB_API_URL: string = environment.apiUrl;
  private auth = localStorage.getItem("token");

  getLibros(): Observable<Array<LibroModel>> {
    const myHeaders = new HttpHeaders().set("token",localStorage.getItem('token'));
    myHeaders.append("Accept", "application/json");
    myHeaders.append('Access-Control-Allow-Headers', 'Content-Type');
    myHeaders.append('Access-Control-Allow-Methods', 'GET');
    myHeaders.append('Access-Control-Allow-Origin', '*');
    const httpOptions = {
      headers: myHeaders,
    };

    return this._httpService.get<Array<LibroModel>>(
      this.WEB_API_URL + "Book",
      httpOptions
    );
  }

  postLibro(libro: LibroModel): Observable<string> {
    const myHeaders = new HttpHeaders().set("token",localStorage.getItem('token'));
    myHeaders.append("Accept", "application/text");
    myHeaders.append('Access-Control-Allow-Headers', 'Content-Type');
    myHeaders.append('Access-Control-Allow-Methods', 'GET');
    myHeaders.append('Access-Control-Allow-Origin', '*');

    const httpOptions = {
      headers: myHeaders,
    };
    console.log(libro);
    return this._httpService.post<string>(
      this.WEB_API_URL + "Book",
      libro,
      httpOptions
    );

  }

  putLibro(id: Number ,libro: LibroModel): Observable<any> {
    const myHeaders = new HttpHeaders().set("token",localStorage.getItem('token'));
    myHeaders.append("Accept", "application/text");
    myHeaders.append('Access-Control-Allow-Headers', 'Content-Type');
    myHeaders.append('Access-Control-Allow-Methods', 'GET');
    myHeaders.append('Access-Control-Allow-Origin', '*');
    const httpOptions = {
      headers: myHeaders,
    };
    return this._httpService.put<string>(
      this.WEB_API_URL + "Book/"+id,
      libro,
      httpOptions
    );
  }

  actualizar(): Observable<any> {
    const myHeaders = new HttpHeaders().set("key",localStorage.getItem('apikey'));
    var key = localStorage.getItem('apikey');
    console.log(localStorage.getItem('apikey'));
    myHeaders.append("Accept", "application/text");
    myHeaders.append('Access-Control-Allow-Headers', 'Content-Type');
    myHeaders.append('Access-Control-Allow-Methods', 'GET');
    myHeaders.append('Access-Control-Allow-Origin', '*');
    const httpOptions = {
      headers: myHeaders,
    };
    return this._httpService.put<string>(
      this.WEB_API_URL + "Organization",
      key,
      httpOptions
      
    );
  }

  getapikey(): Observable<string> {
    const myHeaders = new HttpHeaders().set("token",localStorage.getItem('token'));
    myHeaders.append("Accept", "application/json");
    myHeaders.append('Access-Control-Allow-Headers', 'Content-Type');
    myHeaders.append('Access-Control-Allow-Methods', 'GET');
    myHeaders.append('Access-Control-Allow-Origin', '*');
    const httpOptions = {
      headers: myHeaders,
    };

    return this._httpService.get<string>(
      this.WEB_API_URL + "Organization",
      httpOptions
    );
  }

  deleteLibro(id: Number): Observable<string> {
    const myHeaders = new HttpHeaders().set("token",localStorage.getItem('token'));
    myHeaders.append("Accept", "application/text");
    myHeaders.append('Access-Control-Allow-Headers', 'Content-Type');
    myHeaders.append('Access-Control-Allow-Methods', 'GET');
    myHeaders.append('Access-Control-Allow-Origin', '*');
    console.log(myHeaders);
    const httpOptions = {
      headers: myHeaders,
    };
    return this._httpService.delete<string>(
      this.WEB_API_URL + "Book/"+id ,
      httpOptions
    );
    }

}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ComprarAccionesService {
  url:string="http://localhost:3000/titulos";

  constructor(private http:HttpClient) { }

  getDatosAccion():Observable<any>
  {
      return this.http.get(this.url);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ComprarAccionesService {
  url: string = "http://localhost:3000/titulos";

  constructor(private http: HttpClient) { }

  getDatosAccion(): Observable<any> {
    return this.http.get<Accion[]>(this.url);
  }
}

export class Accion {
  simbolo!: string;
  descripcion!: string;
  ultimoPrecio!: number;
  puntas!: {
    cantidadCompra: number;
    precioCompra: number;
    precioVenta: number;
    cantidadVenta: number;
  } | null;
  apertura!: number;
  maximo!: number;
  minimo!: number;
  ultimoCierre!: number;
}

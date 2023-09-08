import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ComprarAccionesService {
  url: string = "./assets/Data/06-07-23.json";

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

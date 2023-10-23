import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { CompraDto } from '../Dtos/TransaccionDtos/CompraDto';

@Injectable({
  providedIn: 'root'
})
export class ComprarAccionesService {
  url: string = "./assets/Data/06-07-23.json";
  simbolo:string = '';

  private apiUrl = 'https://localhost:7042/api/Usuario';

  constructor(private http: HttpClient) { }

  getDatosAccion(): Observable<any> {
    return this.http.get<Accion[]>(this.url);
  }
  getAccionSeleccionada(simboloAccion:string){
    this.simbolo = simboloAccion
  }

  

  realizarCompra(compra: CompraDto){

    return this.http.post(this.apiUrl, compra);

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

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { CompraDto } from '../Dtos/TransaccionDtos/CompraDto';
import { Accion } from './Accion';

@Injectable({
  providedIn: 'root'
})
export class ComprarAccionesService {
  url: string = "./assets/Data/06-07-23.json";
  simbolo:string = '';
  id:number = 0;

  private apiTransaccion = 'https://localhost:44342/api/Transaccion'
  private apiAccion = 'https://localhost:44342/api/Accion';

  constructor(private http: HttpClient) { }

  getDatosAccion(): Observable<any> {
    return this.http.get<Accion[]>(this.url);
  }
  
  getAccionSeleccionada(simboloAccion:string){
    this.simbolo = simboloAccion
  }

  realizarCompra(compra: CompraDto){

    return this.http.post(this.apiTransaccion, compra);

  }

  getAccionApi():Observable<any>{
    return this.http.get<Accion[]>(this.apiAccion);
  }
}



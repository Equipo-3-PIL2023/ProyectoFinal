import { Injectable } from '@angular/core';
import { NewUsuarioDto } from '../Dtos/UsuarioDtos/NewUsuarioDto';
import { UsuarioDto } from '../Dtos/UsuarioDtos/UsuarioDto';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  constructor(private http:HttpClient) { }

  getPresonaList():Observable<UsuarioDto[]>{
    return this.http.get<UsuarioDto[]>(environment.url)
  }

  createUsuario(usuario : NewUsuarioDto):Observable<UsuarioDto>{
    return this.http.post<UsuarioDto>("https://localhost:44342/api/Usuario", usuario);
  } 
}

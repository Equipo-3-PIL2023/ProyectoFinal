import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, from, switchMap, tap } from 'rxjs';
import { Router } from '@angular/router';
import { Cuenta } from '../pages/portafolio/clases/cuenta';
@Injectable({
  providedIn: 'root'
})



export class AuthService {

  url: string = "https://localhost:44342/api/login";
  urlCuenta:string = ""
  urlActualizarCuenta:string = "https://localhost:44342/actualizar/"
  urlUsuario:string = ""
  userLoginOn:BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  constructor(private http: HttpClient, private route:Router) { 
 
  }

  login(loginRequest:any):Observable<any>
  {    
     return this.http.post(this.url,loginRequest).pipe(
      tap((loginData) => {
        this.userLoginOn.next(true);
        this.urlUsuario = "https://localhost:44342/User/" + loginData;
      })
    )
  }


  logout() {  
    this.userLoginOn.next(false); 
    this.route.navigate(['/login']);
  }


  get isUserLoginOn():Observable<boolean>{
    return this.userLoginOn.asObservable();
  }

  getCuenta():Observable<any>{
    return this.http.get(this.urlUsuario)    
  }

  actualizarSaldo(cuenta:Cuenta):Observable<any>{  
    return from(this.getCuenta()).pipe(
      switchMap((cuentaData) => {        
        cuenta.idCuenta = cuentaData.idCuenta        
        return this.http.put(this.urlActualizarCuenta,cuenta)
      })
    )   
  }

  getPortafolio(): Observable<any> {  
    return from(this.getCuenta()).pipe(
      switchMap((data2) => {       
        this.urlCuenta = "https://localhost:44342/api/Portafolio/" + data2.idCuenta;       
        return this.http.get(this.urlCuenta);
      })
    );
  }
}

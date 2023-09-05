import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, tap } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

   url: string = "https://reqres.in/api/login";
   urlPortafolio:string = "https://my-json-server.typicode.com/MaximoGalindo/users/portafolio"
  userLoginOn:BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  constructor(private http: HttpClient) { }

  login(loginRequest:any):Observable<any>
  {
    return this.http.post(this.url,loginRequest).pipe(
      tap((loginData) => {
        console.log(loginData);
        this.userLoginOn.next(true);
      })
    )
  }

  get isUserLoginOn():Observable<boolean>{
    return this.userLoginOn.asObservable();
  }

  getPortafolio():Observable<any>{
    return this.http.get(this.urlPortafolio)
  }
}

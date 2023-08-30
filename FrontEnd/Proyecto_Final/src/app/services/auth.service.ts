import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  url: string = "https://reqres.in/api/login";
  constructor(private http: HttpClient) { }

  login(loginRequest:any):Observable<any>
  {
    return this.http.post(this.url,loginRequest)
  }
}

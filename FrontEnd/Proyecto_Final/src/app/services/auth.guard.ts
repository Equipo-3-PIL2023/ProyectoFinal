import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Injectable } from '@angular/core'
import { Observable, map, take } from 'rxjs'
import { AuthService } from './auth.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService:AuthService, private router:Router){

  }
  canActivate(
    route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
      //
      return this.authService.isUserLoginOn.pipe(
        take(1),
        map((isUserLoginOn:boolean) =>{
          if (!isUserLoginOn) {
            this.router.navigate(['/login']);
          }
          return isUserLoginOn
        })
        );
    }
}

function tap(arg0: (userLoginOn: any) => void): import('rxjs').OperatorFunction<boolean, unknown>{
  throw new Error('Function not implemented.');
}
import { ChangeDetectorRef, Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  imagenlogo: string = "./assets/imagenes/logo-solo.png";
  // isNavbarCollapsed = true;
  isLogin:boolean=true;
  
  constructor(private authService: AuthService, private route: Router) {
    
  }
 
  
  // toggleNavbar() {
  //   this.isNavbarCollapsed = !this.isNavbarCollapsed;
  // }
  ngOnInit() {
    this.authService.isUserLoginOn.subscribe({
      next:(isLoginOn:boolean)=>{
        console.log(this.isLogin);
        this.isLogin =! isLoginOn
      }
    })
  }

  logOut(){
    this.isLogin=false;
    this.authService.logout()
  }
  
}

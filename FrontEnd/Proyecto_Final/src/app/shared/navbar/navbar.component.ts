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
  isLogin:boolean=false;
  
  constructor(private authService: AuthService, private route: Router) {
    
  }
 
  
  // toggleNavbar() {
  //   this.isNavbarCollapsed = !this.isNavbarCollapsed;
  // }
  ngOnInit() {
 
  }

  logOut(){
    this.isLogin=false;
    this.authService.logout()
  }
  
}

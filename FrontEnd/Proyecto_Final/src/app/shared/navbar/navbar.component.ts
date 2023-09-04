import { Component } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  loginOff:boolean = true;
  constructor(private authService:AuthService){
    
  }

  ngOnInit(){
    this.authService.isUserLoginOn.subscribe({
      next:(isUserLoginOn:boolean)=>{
        this.loginOff =! isUserLoginOn;
      }
    })
  } 
}

import { Component } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent {
  imagenlogo:string= "./assets/imagenes/logo-solo.png";
  logofacebook:string="./assets/imagenes/Facebook.png";
  logotwitter:string="./assets/imagenes/twitter.png";
  logoapple:string="./assets/imagenes/apple.png";
  logoLinkedin:string="./assets/imagenes/LinkedIn.png";
  logoplaystore:string="./assets/imagenes/playstore.png";
  logoinstagram:string="./assets/imagenes/instagram.png";
}
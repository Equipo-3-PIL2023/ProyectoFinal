import { Component, OnInit } from '@angular/core';
import { Portafolio } from './clases/portafolio';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-portafolio',
  templateUrl: './portafolio.component.html',
  styleUrls: ['./portafolio.component.css']
})
export class PortafolioComponent implements OnInit {

  saldoCuenta:number = 0;
  totalInvertido: number = 0;
  portafolio: Portafolio[] = [
    
  ];
  

  constructor(private authService:AuthService) { }

  ngOnInit() {
    this.authService.getPortafolio().subscribe({
      next: (data) => {
        console.log(data);       
        const portafolioItem = data[0];
        this.totalInvertido = portafolioItem.totalInvertido;
        this.saldoCuenta = portafolioItem.saldoCuenta;
        this.portafolio = portafolioItem.acciones
        
        this.portafolio = portafolioItem.acciones.map((item: any) => ({
          accion: item.accion,
          cantidad: item.cantidad,
          valor: item.valor,
          ganancia: item.ganancia,
          perdida: item.perdida
        }));
        console.log(this.portafolio);
      },
      error: (error) => {console.log(error);},
      complete:()=> {}
    })
  }


}

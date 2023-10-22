import { Component, OnInit } from '@angular/core';
import { Portafolio } from './clases/portafolio';
import { AuthService} from 'src/app/services/auth.service';
import { Acciones } from './clases/acciones';
import { ComprarAccionesService } from 'src/app/services/comprar-acciones.service';
import { forkJoin } from 'rxjs';
import { Cuenta } from './clases/cuenta';

@Component({
  selector: 'app-portafolio',
  templateUrl: './portafolio.component.html',
  styleUrls: ['./portafolio.component.css']
})
export class PortafolioComponent implements OnInit {

  saldoCuenta:number = 0;
  totalInvertido: number = 0;
  portafolio: Acciones[] = [];
  cotizaciones: any;

  constructor(private authService:AuthService, private comprarAccionesService:ComprarAccionesService) { }

  ngOnInit() {
        const cotizaciones$ = this.comprarAccionesService.getDatosAccion();
        const portafolio$ = this.authService.getPortafolio();
      
        forkJoin([cotizaciones$, portafolio$]).subscribe(([cotizacionesData, portafolioData]) => {
          console.log(cotizacionesData);
          console.log(portafolioData);
      
          
          this.portafolio = this.createPortafolio(cotizacionesData.titulos, portafolioData.acciones, portafolioData);
          
          console.log(this.portafolio);
        });
      
      }

      createPortafolio(cotizaciones: any[], acciones: any[], portafolioData: any) {       
        const portafolio: Acciones[] = [];
        let cuenta: Cuenta = new Cuenta();
       
        this.saldoCuenta = portafolioData.saldoCuenta;

        

        for (const accion of acciones) {
          const cotizacion = cotizaciones.find(item => item.simbolo === accion.simbolo);
          if (cotizacion) {
            const nuevaAccion = new Acciones();
            nuevaAccion.accion = accion.nombre;
            nuevaAccion.valorAccion = cotizacion.puntas.precioVenta;
            nuevaAccion.cantidad = accion.cantidad;
            nuevaAccion.valor = cotizacion.puntas.precioVenta * accion.cantidad;
            
            this.totalInvertido += accion.cantidad * cotizacion.puntas.precioVenta
            cuenta.totalInvertido = this.totalInvertido
            const valorVenta = cotizacion.puntas.precioVenta * accion.cantidad;     
            const ultimoValor = cotizacion.ultimoPrecio * accion.cantidad;

            if ( ultimoValor > valorVenta) {
              nuevaAccion.ganancia = ultimoValor - valorVenta;
              nuevaAccion.perdida = 0;
              cuenta.saldo = this.saldoCuenta + nuevaAccion.ganancia
            } else {
              nuevaAccion.ganancia = 0;
              nuevaAccion.perdida = ultimoValor - valorVenta;
              cuenta.saldo = this.saldoCuenta - nuevaAccion.perdida
            }          

            this.authService.actualizarSaldo(cuenta)
            portafolio.push(nuevaAccion);
          }

        }

        return portafolio;
      }
       
    


}

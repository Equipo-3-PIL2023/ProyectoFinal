import { Component, OnInit } from '@angular/core';
import { ComprarAccionesService } from 'src/app/services/comprar-acciones.service';
import { ComprarAccionesComponent } from '../comprarAcciones/comprarAcciones.component';
import { Accion } from 'src/app/services/Accion';

@Component({
  selector: 'app-tablaCotizaciones',
  templateUrl: 'tablaCotizaciones.component.html',
  styleUrls: ['tablaCotizaciones.component.css']
})
export class TablaCotizacionesComponent implements OnInit {
  cotizaciones: any;

  constructor(private comprarAccionesService: ComprarAccionesService) { }

  ngOnInit() {
    this.comprarAccionesService.getDatosAccion().subscribe(data => {
      /*data.forEach((objeto: Accion) => {
        console.log(objeto.simbolo);
        console.log(objeto.descripcion);
      });
      this.cotizaciones = data;*/
      this.cotizaciones = data["titulos"];
      console.log(data);
    });
  }

  cargarAccion(item:any){
    this.comprarAccionesService.getAccionSeleccionada(item)
  }

}

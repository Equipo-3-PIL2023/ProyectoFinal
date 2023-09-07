import { getCurrencySymbol } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { find } from 'rxjs';
import { ComprarAccionesService } from 'src/app/services/comprar-acciones.service';

@Component({
  selector: 'app-comprarAcciones',
  templateUrl: './comprarAcciones.component.html',
  styleUrls: ['./comprarAcciones.component.css']
})
export class ComprarAccionesComponent implements OnInit {
  listSimbolos:any;
  dropDownValue:string ='no modificado';
  symbolDrop:any;
  precioAccion:any;
  precioTotal:number = 0;
  cantidadAccionnes:number = 1;
  constructor(private comprarAccionesService:ComprarAccionesService) { }

  ngOnInit(): void{
    this.comprarAccionesService.getDatosAccion().subscribe({
      next: (listSimbolos) => {
        this.listSimbolos = listSimbolos
        this.precioAccion = this.listSimbolos[0].puntas.precioCompra ==
         null ? "Sin precio definido": Number(this.listSimbolos[0].puntas.precioCompra);
         this.calcularTotal(this.cantidadAccionnes)
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        console.info("get simbolos complete")
      }
    });
  }

  getSimbolos(){
    this.comprarAccionesService.getDatosAccion().subscribe({
      next: (listSimbolos) => {
        this.listSimbolos = listSimbolos
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        console.info("get simbolos complete")
      }
    });
  }

  getSimboloDropdown(value:string){
    console.log("cambios realizados")
    return this.dropDownValue=value;    
  }

  getBySimbolo(simbolo:any){
      for (let item of this.listSimbolos){
        if (item.simbolo === simbolo){
          this.precioAccion = !item.puntas? "Sin precio definido" : Number(item.puntas.precioCompra);
          return this.precioAccion;
        }
      }
  }

  calcularTotal(cantidad:any){
    this.cantidadAccionnes = cantidad
    this.precioTotal = Number((Number(this.cantidadAccionnes)*Number(this.precioAccion)).toFixed(2));;
    return this.precioTotal
  }

}

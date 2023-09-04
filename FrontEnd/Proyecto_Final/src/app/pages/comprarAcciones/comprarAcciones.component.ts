import { getCurrencySymbol } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ComprarAccionesService } from 'src/app/services/comprar-acciones.service';

@Component({
  selector: 'app-comprarAcciones',
  templateUrl: './comprarAcciones.component.html',
  styleUrls: ['./comprarAcciones.component.css']
})
export class ComprarAccionesComponent implements OnInit {
  listSimbolos:any;

  constructor(private comprarAccionesService:ComprarAccionesService) { }

  ngOnInit(): void{
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


}

import { getCurrencySymbol } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { find } from 'rxjs';
import { ComprarAccionesService } from 'src/app/services/comprar-acciones.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CompraDto } from 'src/app/Dtos/TransaccionDtos/CompraDto';
import { AuthService } from 'src/app/services/auth.service';


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
  cantidadAcciones:number = 1;
  compraForm:FormGroup;
  accionSeleccionada:any;
  compraDto:CompraDto;

  constructor(private comprarAccionesService:ComprarAccionesService, private formBuilder:FormBuilder, private authService: AuthService) {
    this.compraForm = this.formBuilder.group({
      mercado: ['', Validators.required],
      simbolo: ['', Validators.required],
      cantidad: ['', Validators.required]
    })
    this.compraDto = {

      idUsuario: 0, 
      idCuenta: 0, 
      idAccion: '',
      cantidad: 0,
      saldo: 0

    }
   }

  ngOnInit(): void{
    this.comprarAccionesService.getDatosAccion().subscribe({
      next: (listSimbolos) => {
        this.symbolDrop = this.comprarAccionesService.simbolo
        this.listSimbolos = listSimbolos["titulos"]
        for (let item of this.listSimbolos){
          if (item.simbolo === this.symbolDrop){
            this.accionSeleccionada = item;
          }
        } 
        this.precioAccion = this.accionSeleccionada.puntas.precioCompra ==
        null ? "Sin precio definido": Number(this.accionSeleccionada.puntas.precioCompra);
        this.precioTotal = 0;
        console.log(this.symbolDrop)
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        console.info("get simbolos complete")
      }
    });

    this.authService.getUsuario().subscribe(userData => {
      this.compraDto.idUsuario = userData.idUsuario;
      this.compraDto.saldo = userData.saldo;
    });

    this.authService.getIdCuenta().subscribe(accountData => {

      this.compraDto.idCuenta = accountData.idCuenta;
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
    console.log("Simbolo seleccionado: ", value);
    this.compraDto.idAccion = value;
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
    this.cantidadAcciones = cantidad;
    this.compraDto.cantidad = cantidad;
    this.precioTotal = Number((Number(this.cantidadAcciones)*Number(this.precioAccion)).toFixed(2));
    return this.precioTotal
  }

  comprarAcciones(){
    this.compraDto.idUsuario = 0;
    this.compraDto.idCuenta = 0;
    this.compraDto.saldo = 0;
    
    this.comprarAccionesService.realizarCompra(this.compraDto).subscribe(
      (response) => {
        console.log("Acciones compradas con éxito");
      },
      (error) => {
        console.error("Error al comprar acciones:", error);
      }
      );
    console.log(this.compraDto);
    }
}



import { getCurrencySymbol } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { find } from 'rxjs';
import { ComprarAccionesService } from 'src/app/services/comprar-acciones.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CompraDto } from 'src/app/Dtos/TransaccionDtos/CompraDto';
import { AuthService } from 'src/app/services/auth.service';
import { Accion } from 'src/app/services/Accion';


@Component({
  selector: 'app-comprarAcciones',
  templateUrl: './comprarAcciones.component.html',
  styleUrls: ['./comprarAcciones.component.css']
})
export class ComprarAccionesComponent implements OnInit {
  listSimbolos: any;
  selectedSimbolo: string = 'no modificado';
  symbolDrop: any;
  idAccionDrop: any;
  precioAccion: any;
  precioTotal: number = 0;
  cantidadAcciones: number = 1;
  compraForm: FormGroup;
  accionSeleccionada: any;
  compraDto: CompraDto;
  acciones: any;

  constructor(private comprarAccionesService: ComprarAccionesService, private formBuilder: FormBuilder, private authService: AuthService) {
    this.compraForm = this.formBuilder.group({
      mercado: ['', Validators.required],
      simbolo: ['', Validators.required],
      cantidad: ['', Validators.required]
    })
    this.compraDto = {

      idUsuario: 0,
      idCuenta: 0,
      idAccion: 0,
      cantidad: 0,
      saldo: 0

    }
  }

  ngOnInit(): void {
    this.comprarAccionesService.getDatosAccion().subscribe({
      next: (listSimbolos) => {
        this.symbolDrop = this.comprarAccionesService.simbolo
        this.idAccionDrop = this.comprarAccionesService.id
        this.listSimbolos = listSimbolos["titulos"]
        console.log(this.symbolDrop);
        for (let item of this.listSimbolos) {
          if (item.simbolo === this.symbolDrop) {
            this.accionSeleccionada = item;
          }
        }
        this.precioAccion = this.accionSeleccionada.puntas.precioCompra ==
          null ? "Sin precio definido" : Number(this.accionSeleccionada.puntas.precioCompra);
        this.precioTotal = 0;
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        console.info("get simbolos complete")
      }
    });
    this.comprarAccionesService.getAccionApi().subscribe({
      next: (data: Accion[]) => {
        this.acciones = data;
        console.log(this.acciones);
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        console.info("Obtención de datos de acciones de la completa");
      }
    });
  }

  getSimbolos() {
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

  getSimboloDropdown(simbolo: string) {
    console.log("Simbolo seleccionado: ", simbolo);
    const accionSeleccionada = this.acciones.find((accion: Accion) => accion.simbolo === simbolo);
    console.log("Accion seleccionada: ", accionSeleccionada)
    if (accionSeleccionada) {
      this.compraDto.idAccion = accionSeleccionada.idAccion;
    } else {
      console.error('No se encontró la acción correspondiente al símbolo seleccionado.');
    }
  }
  

  getBySimbolo(simbolo: any) {
    for (let item of this.listSimbolos) {
      if (item.simbolo === simbolo) {
        this.precioAccion = !item.puntas ? "Sin precio definido" : Number(item.puntas.precioCompra);
        return this.precioAccion;
      }
    }
  }

  calcularTotal(cantidad: any) {
    this.cantidadAcciones = cantidad;
    this.compraDto.cantidad = cantidad;
    this.precioTotal = Number((Number(this.cantidadAcciones) * Number(this.precioAccion)).toFixed(2));
    return this.precioTotal
  }

  comprarAcciones() {
    this.compraDto.idUsuario = 0;
    this.compraDto.idCuenta = 0;
    this.compraDto.saldo = 0;

    this.comprarAccionesService.realizarCompra(this.compraDto).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.error("Error al comprar acciones:", error);
      }
    );
    console.log(this.compraDto);
  }
}



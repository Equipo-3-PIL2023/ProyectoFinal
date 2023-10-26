import { formatDate, getCurrencySymbol } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { find } from 'rxjs';
import { ComprarAccionesService } from 'src/app/services/comprar-acciones.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CompraDto } from 'src/app/Dtos/TransaccionDtos/CompraDto';
import { AuthService } from 'src/app/services/auth.service';
import { Accion } from 'src/app/services/Accion';
import { VariableBinding } from '@angular/compiler';
import { Route, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';




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
  cantMax: any;
  cantMin: any;
  detalleCompra: any = {}
  tituloAccion: any;
  simboloAccion: any;
  setupToast = {
    progressBar: true,
    closeButton: true,
  }
  idCuenta: any;
  saldoCuenta: any;


  constructor(private toastr: ToastrService, private comprarAccionesService: ComprarAccionesService, private formBuilder: FormBuilder, private authService: AuthService, private route: Router) {
    var idUser: number;
    this.compraForm = this.formBuilder.group({
      mercado: ['', Validators.required],
      simbolo: ['', Validators.required],
      cantidad: ['', Validators.required]
    })
    this.compraDto = {

      idCuenta: 0,
      idAccion: 0,
      fecha: '',
      precioCompra: 0,
      cantidad: 0,
      comision: 0

    }
  }

  ngOnInit(): void {
    this.comprarAccionesService.getDatosAccion().subscribe({
      next: (listSimbolos) => {
        this.symbolDrop = this.comprarAccionesService.simbolo
        this.listSimbolos = listSimbolos["titulos"]
        for (let item of this.listSimbolos) {
          if (item.simbolo === this.symbolDrop) {
            this.accionSeleccionada = item;
          }
        }
        this.tituloAccion = this.accionSeleccionada.descripcion
        this.simboloAccion = this.accionSeleccionada.simbolo
        this.cantMin = this.accionSeleccionada.laminaMinima
        this.cantMax = this.accionSeleccionada.puntas?.cantidadCompra == null ? "Cantidad maxima no definida" : Number(this.accionSeleccionada.puntas.cantidadCompra);
        this.precioAccion = this.accionSeleccionada.puntas.precioCompra ==
          null ? "Sin precio definido" : Number(this.accionSeleccionada.puntas.precioCompra);
        this.precioTotal = 0;
        console.log("Cantidad maxima de compra de accion: ", this.accionSeleccionada, this.cantMax);
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
        // console.log(this.acciones);
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        console.info("Obtención de datos de acciones de la completa");
      }
    });

    this.authService.getCuenta().subscribe(data => {
      this.compraDto.idCuenta = data.idCuenta;
      this.compraDto.fecha = formatDate(new Date(), 'yyyy-MM-dd', 'en');
    })

    this.authService.getCuenta().subscribe(data => {
      this.idCuenta = data.idCuenta;
      this.compraDto.idCuenta = this.idCuenta;
      console.log(this.idCuenta);
    });

    this.authService.getPortafolio().subscribe(data => {
      this.saldoCuenta = data.saldoCuenta;
    })
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

    this.calcularDetallesCompra(this.cantidadAcciones);

    return this.precioTotal
  }

  comprarAcciones() {

    this.compraDto.precioCompra = this.precioTotal;
    this.compraDto.comision = this.precioTotal * 0.015;

    if (this.saldoCuenta >= (this.precioTotal + (this.precioTotal * 0.015))) {

      this.comprarAccionesService.realizarCompra(this.compraDto).subscribe(
        (response) => {
          this.toastr.success('Compra realizada con éxito', '¡Felicidades!', {
            progressBar: true
          })
          this.route.navigate(['/portafolio'])
          console.log(response);
          const compraExito = "Compra realizada exitosamente"
        },
        (error) => {
          console.error("Error al comprar acciones:", error);
        }
      );
      console.log(this.compraDto);
      console.log("Compra confirmada:", this.detalleCompra);

    } else {
      const errorSaldo = "Error al comprar acciones: Saldo insuficiente";
      this.toastr.error(errorSaldo, 'Oops :(', {
        progressBar: true,
        closeButton: true,
      });
    }
  }

  validarCantidad() {
    const cantidadControl = this.compraForm.get('cantidad');
    if (cantidadControl) {
      const cantidadIntroducida = cantidadControl.value;
      if (cantidadIntroducida > this.cantMax) {
        cantidadControl.setErrors({ maxCantidadExcedida: true });
      } else if (cantidadIntroducida < 1) {
        cantidadControl.setErrors({ minCantidadInvalida: true });
      } else {
        cantidadControl.setErrors(null);
      }
    }
  }

  calcularDetallesCompra(cantidad: any) {
    this.detalleCompra.subtotal = cantidad * this.precioAccion;
    this.detalleCompra.comision = this.detalleCompra.subtotal * 0.015;
    this.detalleCompra.total = this.detalleCompra.subtotal + this.detalleCompra.comision;
  }
}



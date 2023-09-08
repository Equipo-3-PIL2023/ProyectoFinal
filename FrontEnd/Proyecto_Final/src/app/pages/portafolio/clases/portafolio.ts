import { DecimalPipe } from "@angular/common";
import { Acciones } from "./acciones";

export class Portafolio {
    saldoCuenta: number = 0;
    totalInvertido: number = 0;
    acciones: Acciones[] = [];
}

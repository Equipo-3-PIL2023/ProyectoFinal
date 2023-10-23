
export class Accion {
  id: number | undefined;
  simbolo!: string;
  descripcion!: string;
  ultimoPrecio!: number;
  puntas!: {
    cantidadCompra: number;
    precioCompra: number;
    precioVenta: number;
    cantidadVenta: number;
  } | null;
  apertura!: number;
  maximo!: number;
  minimo!: number;
  ultimoCierre!: number;
}

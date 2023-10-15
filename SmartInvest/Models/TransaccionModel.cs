﻿using System.ComponentModel.DataAnnotations;

namespace SmartInvest.Models
{
    public class TransaccionModel
    {
        [Key] public int idTransaccion {  get; set; }
        public int idAcciones { get; set; }
        public int idCuenta { get; set; }
        public DateTime fecha { get; set; }
        public float precioCompra {  get; set; }
        public int cantidad { get; set; }
        public float comision { get; set; }
    }
}

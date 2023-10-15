using SmartInvest.Dtos.TransaccionDto;
using System.ComponentModel.DataAnnotations;

namespace SmartInvest.Models
{
    public class TransaccionModel
    {
        [Key] public int idTransaccion {  get; set; }
        public int idAccion { get; set; }
        public int idCuenta { get; set; }
        public DateTime fecha { get; set; }
        public decimal precioCompra {  get; set; }
        public int cantidad { get; set; }
        public decimal comision { get; set; }

        public TransaccionDto ToDo()
        {
            return new TransaccionDto()
            {
                idTransaccion = idTransaccion,
                idAccion = idAccion,
                idCuenta = idCuenta,
                fecha = fecha,
                precioCompra = precioCompra,
                cantidad = cantidad,
                comision = comision
            };
        }
    }
}

namespace SmartInvest.Dtos.TransaccionDto
{
    public class NewTransaccionDto
    {
        public int idAccion { get; set; }
        public int idCuenta { get; set; }
        public DateTime fecha { get; set; }
        public decimal precioCompra { get; set; }
        public int cantidad { get; set; }
        public decimal comision { get; set; }
    }
}

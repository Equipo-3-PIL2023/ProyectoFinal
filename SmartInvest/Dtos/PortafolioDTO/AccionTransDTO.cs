using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace SmartInvest.Dtos.PortafolioDTO
{
    public class AccionTransDTO
    {
        public int idAccion { get; set; }
        public string nombre { get; set; }
        public string simbolo { get; set; }
        public decimal cantidad { get; set; }   
    }
}
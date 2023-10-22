using SmartInvest.Migrations.AccionDB;
using SmartInvest.Models;

namespace SmartInvest.Dtos.PortafolioDTO
{
    public class PortafolioDTO
    {
        public string UserToken { get; set; }
        public decimal SaldoCuenta { get; set; }
        //public decimal TotalInvertido { get; set; }
        public List<AccionTransDTO> Acciones { get; set; }    
    }
}

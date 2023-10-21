using SmartInvest.Dtos.CuentaDto;
using System.ComponentModel.DataAnnotations;

namespace SmartInvest.Models
{
    public class CuentaModel
    {
        [Key] public int idCuenta { get; set; }
        public int idUsuario { get; set; }
        public decimal saldo { get; set; }

        public CuentaDto ToDo()
        {
            return new CuentaDto()
            {
                idCuenta = idCuenta,
                idUsuario = idUsuario,
                saldo = saldo,
            };
        }
    }
}

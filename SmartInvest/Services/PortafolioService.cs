using SmartInvest.Dtos.PortafolioDTO;
using SmartInvest.Dtos.TransaccionDto;
using SmartInvest.Models;
using SmartInvest.Repositories;

namespace SmartInvest.Services
{
    public class PortafolioService
    {
        private readonly TransaccionDBContext transaccionDBContext;
        private readonly AccionDBContext accionDBContext;
        private readonly CuentaDBContext cuentaDBContext;
 
        public PortafolioService(
            TransaccionDBContext transaccionDBContext,
            CuentaDBContext cuentaDBContext,
            AccionDBContext accionDBContext)
        {
            this.transaccionDBContext = transaccionDBContext;
            this.cuentaDBContext = cuentaDBContext;
            this.accionDBContext = accionDBContext;
        }

        public async Task<PortafolioDTO> getPortafolioByCuenta(int idCuenta)
        {
            PortafolioDTO portafolio = new PortafolioDTO();
            List<TransaccionModel> lTransacciones = await transaccionDBContext.GetTransaccionByCuenta(idCuenta);
            AccionModel accionModel = new AccionModel();
            AccionTransDTO accionTransDTO = new AccionTransDTO();   
            List<AccionTransDTO> lAcciones = new List<AccionTransDTO>();
            CuentaModel cuentaPropietario = await cuentaDBContext.Get(idCuenta);

            
            foreach(TransaccionModel t in lTransacciones)
            {
                accionModel = await accionDBContext.Get(t.idAccion);
                accionTransDTO.nombre = accionModel.nombre;
                accionTransDTO.simbolo = accionModel.simbolo;
                accionTransDTO.idAccion = accionModel.idAccion;
                accionTransDTO.cantidad = t.cantidad;
                lAcciones.Add(accionTransDTO);
                accionTransDTO = new AccionTransDTO();
            }

            portafolio.UserToken = "hola";
            portafolio.SaldoCuenta = cuentaPropietario.saldo;            
            portafolio.Acciones = lAcciones;

            return portafolio;
        }



    }
}

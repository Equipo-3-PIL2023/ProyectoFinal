using SmartInvest.Dtos.CuentaDto;
using SmartInvest.Dtos.TransaccionDto;
using SmartInvest.Models;
using SmartInvest.Repositories;

namespace SmartInvest.Services
{
    public class TransaccionService
    {
        private readonly TransaccionDBContext _transaccionDbContext;
        private readonly CuentaService _cuentaService;

        public TransaccionService(TransaccionDBContext transaccionDbContext, CuentaService cuentaService)
        {
            _transaccionDbContext = transaccionDbContext;
            _cuentaService = cuentaService;
        }

        public async Task<List<TransaccionDto>> Get() 
        { 
            return _transaccionDbContext.Get().Result.Select(c => c.ToDo()).ToList();
        }

        public async Task<List<TransaccionDto>> GetTransaccionesByCuenta(int idCuenta)
        {
            return _transaccionDbContext.GetTransaccionByCuenta(idCuenta).Result.Select( c => c.ToDo()).ToList();
        }

        public async Task<TransaccionDto> Get(int id)
        {
            TransaccionModel result = await _transaccionDbContext.Get(id);
            return result.ToDo();
        }

        public async Task<TransaccionDto> Create(NewTransaccionDto transaccionDto)
        {
            TransaccionModel newTransaccion = new TransaccionModel()
            {
                idCuenta = transaccionDto.idCuenta,
                idAccion = transaccionDto.idAccion,
                fecha = transaccionDto.fecha,
                precioCompra = transaccionDto.precioCompra,
                cantidad = transaccionDto.cantidad,
                comision = transaccionDto.comision
            };
            var cuentaUser = _cuentaService.Get(transaccionDto.idCuenta);
            CuentaSaldoDTO cuentaUpdateSaldo = new CuentaSaldoDTO
            {
                idCuenta = transaccionDto.idCuenta,
                TotalInvertido = transaccionDto.precioCompra + transaccionDto.comision,
                saldo = cuentaUser.Result.saldo
            };
            _cuentaService.ActualizarSaldo(cuentaUpdateSaldo);
            TransaccionModel entity = await _transaccionDbContext.Create(newTransaccion);
            return entity.ToDo();
        }

        public void Delete(int id)
        {
            _transaccionDbContext.Delete(id);
        }
    }
}

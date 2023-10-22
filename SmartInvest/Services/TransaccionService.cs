using SmartInvest.Dtos.TransaccionDto;
using SmartInvest.Models;
using SmartInvest.Repositories;

namespace SmartInvest.Services
{
    public class TransaccionService
    {
        private readonly TransaccionDBContext _transaccionDbContext;

        public TransaccionService(TransaccionDBContext transaccionDbContext)
        {
            _transaccionDbContext = transaccionDbContext;
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

            TransaccionModel entity = await _transaccionDbContext.Create(newTransaccion);
            return entity.ToDo();
        }

        public void Delete(int id)
        {
            _transaccionDbContext.Delete(id);
        }
    }
}

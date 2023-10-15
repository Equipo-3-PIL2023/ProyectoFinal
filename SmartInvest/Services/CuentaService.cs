using SmartInvest.Dtos.CuentaDto;
using SmartInvest.Repositories;
using System.ComponentModel;

namespace SmartInvest.Services
{
    public class CuentaService
    {
        private readonly CuentaDBContext _cuentaDbContext;

        public CuentaService(CuentaDBContext cuentaDbContext)
        {
            _cuentaDbContext = cuentaDbContext;
        }   

        public async Task<List<CuentaDto>> Get()
        {
            return _cuentaDbContext.Get().Result.Select(c => c.ToDo()).ToList();
        } 
    }
}

using SmartInvest.Dtos.TransaccionDto;
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
    }
}

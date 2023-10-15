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
    }
}

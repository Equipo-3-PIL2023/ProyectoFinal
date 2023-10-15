using SmartInvest.Repositories;

namespace SmartInvest.Services
{
    public class AccionService
    {
        private readonly AccionDBContext _accionDbContext;
        public AccionService(AccionDBContext accionDbContext)
        {
            _accionDbContext = accionDbContext;
        }  
    }
}

using SmartInvest.Dtos.AccionDto;
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

        public async Task<List<AccionDto>> Get()
        {
            return _accionDbContext.Get().Result.Select(c => c.ToDo()).ToList();
        }
    }
}

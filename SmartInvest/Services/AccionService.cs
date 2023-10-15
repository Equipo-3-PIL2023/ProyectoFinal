using SmartInvest.Dtos.AccionDto;
using SmartInvest.Models;
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

        public async Task<AccionDto> Get(int id)
        {
            AccionModel result = await _accionDbContext.Get(id);
            return result.ToDo();
        }

        public async Task<AccionDto> Create(NewAccionDto accionDto)
        {
            AccionModel newAccion = new AccionModel
            {
                nombre = accionDto.nombre,
                simbolo = accionDto.simbolo
            };
            AccionModel entity = await _accionDbContext.Create(newAccion);
            return entity.ToDo();
        }

        public void Delete(int id)
        {
            _accionDbContext.Delete(id);
        }
    }
}

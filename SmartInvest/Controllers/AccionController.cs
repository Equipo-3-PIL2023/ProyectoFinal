using Microsoft.AspNetCore.Mvc;
using SmartInvest.Dtos.AccionDto;
using SmartInvest.Services;

namespace SmartInvest.Controllers
{
    [Route("api/Accion")]
    [ApiController]
    public class AccionController : Controller
    {
        private readonly AccionService _accionService;

        public AccionController(AccionService accionService)
        {
            _accionService = accionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<AccionDto> result = await _accionService.Get();
            return new ObjectResult(result);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SmartInvest.Dtos.AccionDto;
using SmartInvest.Migrations;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            AccionDto result = await _accionService.Get(id);
            return result != null ? Ok(result) : null;
        }


        [HttpPost]
        public async Task<IActionResult> Create(NewAccionDto accionDto)
        {
            return Ok(await _accionService.Create(accionDto));
        }
    }
}

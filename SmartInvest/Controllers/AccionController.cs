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

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            _accionService.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, NewAccionDto accionDto)
        {
            AccionDto existingAccion = await _accionService.Get(id);

            if (existingAccion == null)
            {
                return NotFound();
            }

            AccionDto updatedAccion = new AccionDto
            {
                idAccion = id,
                nombre = accionDto.nombre,
                simbolo = accionDto.simbolo,
            };

            AccionDto result = await _accionService.Update(id, updatedAccion);

            return Ok(result);

        }

    }
}

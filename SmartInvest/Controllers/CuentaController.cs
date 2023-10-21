using Microsoft.AspNetCore.Mvc;
using SmartInvest.Dtos.CuentaDto;
using SmartInvest.Services;

namespace SmartInvest.Controllers
{
    [Route("api/Cuenta")]
    [ApiController]
    public class CuentaController : Controller
    {
        private readonly CuentaService _cuentaService;

        public CuentaController(CuentaService cuentaService)
        {
            _cuentaService = cuentaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<CuentaDto> result = await _cuentaService.Get();
            return new ObjectResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            CuentaDto result = await _cuentaService.Get(id);
            return result != null ? Ok(result) : null;
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewCuentaDto cuentaDto)
        {
            return Ok(await _cuentaService.Create(cuentaDto));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            _cuentaService.Delete(id);
            return Ok();
        } 
    }
}

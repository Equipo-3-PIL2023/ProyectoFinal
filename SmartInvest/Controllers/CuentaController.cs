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
    }
}

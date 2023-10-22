using Microsoft.AspNetCore.Mvc;
using SmartInvest.Dtos.PortafolioDTO;
using SmartInvest.Services;

namespace SmartInvest.Controllers
{
    [Route("api/Portafolio")]
    [ApiController]
    public class PortafolioController : Controller
    {
        private readonly PortafolioService _portafolioService;

        public PortafolioController(PortafolioService portafolioService)
        {
            _portafolioService = portafolioService;
        }

        [HttpGet("{idCuenta}")]
        public async Task<IActionResult> Get(int idCuenta)
        {           
            PortafolioDTO result = await _portafolioService.getPortafolioByCuenta(idCuenta);           
            return new ObjectResult(result);
        }

    }
}

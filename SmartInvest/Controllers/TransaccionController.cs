using Microsoft.AspNetCore.Mvc;
using SmartInvest.Dtos.TransaccionDto;
using SmartInvest.Services;

namespace SmartInvest.Controllers
{
    [Route("api/Transaccion")]
    [ApiController]
    public class TransaccionController : Controller
    {
        private readonly TransaccionService _transaccionService;

        public TransaccionController(TransaccionService transaccionService)
        {
            _transaccionService = transaccionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<TransaccionDto> result = await _transaccionService.Get();
            return new ObjectResult(result);
        }
    }
}

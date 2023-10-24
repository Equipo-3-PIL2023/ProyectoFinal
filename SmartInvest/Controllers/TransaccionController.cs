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
        private readonly CuentaService _cuentaService;

        public TransaccionController(TransaccionService transaccionService, CuentaService cuentaService)
        {
            _transaccionService = transaccionService;
            _cuentaService = cuentaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<TransaccionDto> result = await _transaccionService.Get();
            return new ObjectResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            TransaccionDto result = await _transaccionService.Get(id);
            return result != null ? Ok(result) : null;
        }

        [HttpGet("cuenta/{idCuenta}")]
        public async Task<IActionResult> GetTransaccionesByCuenta(int idCuenta)
        {
            List<TransaccionDto> result = await _transaccionService.GetTransaccionesByCuenta(idCuenta);
            return result != null ? Ok(result) : null;
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewTransaccionDto transaccionDto)
        {
            var cuentaUsuario = _cuentaService.Get(transaccionDto.idCuenta);
            if (cuentaUsuario.Result.saldo >= transaccionDto.precioCompra + transaccionDto.comision)
            {
                return Ok(await _transaccionService.Create(transaccionDto));
            }
            else
            {
                return BadRequest("Saldo insuficiente");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            _transaccionService.Delete(id);
            return Ok();
        }
    }
}

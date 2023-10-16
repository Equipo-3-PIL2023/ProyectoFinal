using Microsoft.AspNetCore.Mvc;
using SmartInvest.Dtos.UsuarioDto;
using SmartInvest.Services;

namespace SmartInvest.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly UsuarioService _usuarioService;
        public LoginController(UsuarioService suarioService)
        {
            _usuarioService = suarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            UsuarioDto usuario = await _usuarioService.Login(loginDto.correo, loginDto.password);
            return usuario != null ? Ok(true) : null;
        }
    }
}

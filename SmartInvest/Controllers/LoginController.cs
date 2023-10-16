using Microsoft.AspNetCore.Mvc;
using SmartInvest.Dtos.UsuarioDto;
using SmartInvest.Services;

namespace SmartInvest.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            UsuarioDto usuario = await _loginService.Login(loginDto.email, loginDto.password);
            return usuario != null ? Ok(true) : null;
        }
    }
}

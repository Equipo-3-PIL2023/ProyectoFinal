using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using SmartInvest.Dtos.UsuarioDto;
using SmartInvest.Services;
using System.Diagnostics.CodeAnalysis;

namespace SmartInvest.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _userService;
        public UsuarioController(UsuarioService userService)
        {
            _userService = userService;
        }
        //api/usuario/
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<UsuarioDto> result = await _userService.Get();
            return new OkObjectResult(result);
        }
        //api/usuario/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            //UserDto result = await _userService.Get(id);
            //return new OkObjectResult(result);

            UsuarioDto usuario = await _userService.Get(id);
            return usuario != null ? Ok(usuario) : null;
        }

        /*
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return new OkObjectResult(await _userService.Delete(id));
        }*/


        [HttpPost]
        public async Task<IActionResult> Create(NewUsuarioDto clientDto)
        {
            return Ok(await _userService.Create(clientDto));
        }


        /*
        [HttpPut]
        public async Task<IActionResult> Update(UserDto clienteDto)
        {
            var result = await _userService.Update(clienteDto);
        if (result == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(result);
        }

        */
    }
}

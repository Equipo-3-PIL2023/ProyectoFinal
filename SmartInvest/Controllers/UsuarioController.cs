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
            UsuarioDto usuario = await _userService.Get(id);
            return usuario != null ? Ok(usuario) : null;
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewUsuarioDto clientDto)
        {
            return Ok(await _userService.Create(clientDto));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
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


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, NewUsuarioDto usuarioDto)
        {            
            UsuarioDto existingUser = await _userService.Get(id);

            if (existingUser == null)
            {
                return NotFound();
            }
                        
            UsuarioDto updatedUser = new UsuarioDto
            {
                Id = id,
                Nombre = usuarioDto.Nombre,
                Apellido = usuarioDto.Apellido,
                Email = usuarioDto.Email,                                          
                Dni = usuarioDto.Dni,
                TipoDocumento = usuarioDto.TipoDocumento,
                Telefono = usuarioDto.Telefono,
                CodigoPostal = usuarioDto.CodigoPostal,
                Ciudad = usuarioDto.Ciudad,
                Provincia = usuarioDto.Provincia,
                Pais = usuarioDto.Pais,
            };
                        
            UsuarioDto result = await _userService.Update(id, updatedUser);

            return Ok(result);
        }


    }
}

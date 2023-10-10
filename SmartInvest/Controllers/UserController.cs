using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using SmartInvest.Dtos;
using SmartInvest.Services;
using System.Diagnostics.CodeAnalysis;

namespace SmartInvest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        //api/usuario/
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<UserDto> result = await _userService.Get();
            return new OkObjectResult(result);
        }
        //api/usuario/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            UserDto result = await _userService.Get(id);
            return new OkObjectResult(result);
        }

        /*
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return new OkObjectResult(await _userService.Delete(id));
        }*/


        [HttpPost]
        public async Task<IActionResult> Create(NewUserDto clientDto)
        {
            UserDto cliente = await _userService.Create(clientDto);
            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
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

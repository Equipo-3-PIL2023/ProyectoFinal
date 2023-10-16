using SmartInvest.Dtos.UsuarioDto;
using SmartInvest.Models;
using SmartInvest.Repositories;

namespace SmartInvest.Services
{
    public class LoginService
    {
        private readonly UsuarioDBContext _usuarioDbContext;
        private readonly AESEncriptadorService _AESEncriptadorService;

        public LoginService(UsuarioDBContext usuarioDbContext, AESEncriptadorService aESEncriptadorService)
        {
            _usuarioDbContext = usuarioDbContext;
            _AESEncriptadorService = aESEncriptadorService;
        }

        public async Task<UsuarioDto> Login(string correo, string password)
        {
            password = _AESEncriptadorService.Encriptar(password);

            UsuarioModel result = await _usuarioDbContext.Login(correo, password);
            return result.ToDto();
        }
    }
}

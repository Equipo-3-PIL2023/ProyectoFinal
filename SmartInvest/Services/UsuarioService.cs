using SmartInvest.Dtos.UsuarioDto;
using SmartInvest.Models;
using SmartInvest.Repositories;

namespace SmartInvest.Services
{
    public class UsuarioService { 

    private readonly UsuarioDBContext _myDbContext;
    public UsuarioService(UsuarioDBContext myDBContext)
    {
        _myDbContext = myDBContext;
    }
    public async Task<List<UserDto>> Get()
    {
        return _myDbContext.Get().Result.Select(c => c.ToDto()).ToList();
    }
    public async Task<UserDto> Get(int id)
    {
        UsuarioModel result = await _myDbContext.Get(id);
        return result.ToDto();
    }
        /*
       public async Task<bool> Delete(int id)
       {
           var result = await _myDbContext.Delete(id);
           return result;
       }*/
        public async Task<UserDto> Create(NewUserDto userDto)
        {
            UsuarioModel newClient = new UsuarioModel{
            nombre = userDto.Nombre,
            apellido = userDto.Apellido,
            correo = userDto.Email,
            password = userDto.Password,
            dni = userDto.Dni,
            tipoDni = userDto.TipoDocumento,
            telefono = userDto.Telefono,
            codigoPostal = userDto.CodigoPostal,
            ciudad = userDto.Ciudad,
            provincia = userDto.Provincia,
            pais = userDto.Pais,
            fechaNacimiento = userDto.FechaNacimiento,
        };

        UsuarioModel entity = await _myDbContext.Create(newClient);
        return entity.ToDto();
    }

    /*
    public async Task<UserDto> Update(UserDto user)
    {
        var entity = await _myDbContext.Get(user.Id);
        if (entity == null)
        {
            return null;
        }
            entity.Nombre = user.Nombre;
            entity.Apellido = user.Apellido;
            entity.Email = user.Email;
            entity.Password = user.Password;
            entity.Dni = user.Dni;
            entity.TipoDocumento = user.TipoDocumento;
            entity.CodigoPostal = user.CodigoPostal;
            entity.Ciudad = user.Ciudad;
            entity.Provincia = user.Provincia;
            entity.Pais = user.Pais;
            entity.FechaNacimiento = user.FechaNacimiento;
            await _myDbContext.Update(entity);
        return entity.ToDto();
    }
    */
    }
}

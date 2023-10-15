﻿using SmartInvest.Dtos.UsuarioDto;
using SmartInvest.Models;
using SmartInvest.Repositories;

namespace SmartInvest.Services
{
    public class UsuarioService { 

    private readonly UsuarioDBContext _usuarioDbContext;
    public UsuarioService(UsuarioDBContext myDBContext)
    {
        _usuarioDbContext = myDBContext;
    }
    public async Task<List<UsuarioDto>> Get()
    {
        return _usuarioDbContext.Get().Result.Select(c => c.ToDto()).ToList();
    }
    public async Task<UsuarioDto> Get(int id)
    {
        UsuarioModel result = await _usuarioDbContext.Get(id);
        return result.ToDto();
    }
        /*
       public async Task<bool> Delete(int id)
       {
           var result = await _usuarioDbContext.Delete(id);
           return result;
       }*/
        public async Task<UsuarioDto> Create(NewUsuarioDto userDto)
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

        UsuarioModel entity = await _usuarioDbContext.Create(newClient);
        return entity.ToDto();
    }

    /*
    public async Task<UserDto> Update(UserDto user)
    {
        var entity = await _usuarioDbContext.Get(user.Id);
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
            await _usuarioDbContext.Update(entity);
        return entity.ToDto();
    }
    */
    }
}
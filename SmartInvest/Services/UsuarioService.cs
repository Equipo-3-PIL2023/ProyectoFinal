﻿using Azure;
using SmartInvest.Dtos.CuentaDto;
using SmartInvest.Dtos.UsuarioDto;
using SmartInvest.Models;
using SmartInvest.Repositories;
using System.Security.Cryptography;

namespace SmartInvest.Services
{
    public class UsuarioService
    {

        private readonly UsuarioDBContext _usuarioDbContext;
        private readonly CuentaDBContext _cuentaDbContext;
        private readonly AESEncriptadorService _AESEncriptadorService;
        public UsuarioService(UsuarioDBContext myDBContext, CuentaDBContext cuentaDBContext ,AESEncriptadorService aESEncriptadorService)
        {
            _usuarioDbContext = myDBContext;
            _AESEncriptadorService = aESEncriptadorService;
            _cuentaDbContext = cuentaDBContext;
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

        public async Task<UsuarioDto> Create(NewUsuarioDto userDto)
        {
            
            string password = _AESEncriptadorService.Encriptar(userDto.Password);
            DateTime fechaNacimiento = new DateTime(userDto.Year, userDto.Month, userDto.Day);


            UsuarioModel newClient = new UsuarioModel
            {
                nombre = userDto.Nombre,
                apellido = userDto.Apellido,
                correo = userDto.Email,
                password = password,
                dni = userDto.Dni,
                tipoDni = userDto.TipoDocumento,
                telefono = userDto.Telefono,
                codigoPostal = userDto.CodigoPostal,
                ciudad = userDto.Ciudad,
                provincia = userDto.Provincia,
                pais = userDto.Pais,
                fechaNacimiento = fechaNacimiento,
            };

            UsuarioModel entity = await _usuarioDbContext.Create(newClient);

            CuentaModel newCuenta = new CuentaModel
            {
                idUsuario = entity.idUsuario,
                saldo = 1000000
            };

            CuentaModel cuenta = await _cuentaDbContext.Create(newCuenta);

            return entity.ToDto();
        }

        public void Delete(int id)
        {
            _usuarioDbContext.Delete(id);
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

        public async Task<UsuarioDto> Update(int id, UsuarioDto usuarioDto)
        {
            UsuarioModel existingUser = await _usuarioDbContext.Get(id);

            if (existingUser == null)
            {
                return null;
            }
                        
            existingUser.nombre = usuarioDto.Nombre;
            existingUser.apellido = usuarioDto.Apellido;
            existingUser.correo = usuarioDto.Email;            
            existingUser.dni = usuarioDto.Dni;
            existingUser.tipoDni = usuarioDto.TipoDocumento;
            existingUser.telefono = usuarioDto.Telefono;
            existingUser.codigoPostal = usuarioDto.CodigoPostal;
            existingUser.ciudad = usuarioDto.Ciudad;
            existingUser.provincia = usuarioDto.Provincia;
            existingUser.pais = usuarioDto.Pais;

            await _usuarioDbContext.SaveChangesAsync();

            return existingUser.ToDto();
        }


    }
}

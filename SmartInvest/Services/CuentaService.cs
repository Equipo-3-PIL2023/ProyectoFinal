﻿using SmartInvest.Dtos.CuentaDto;
using SmartInvest.Models;
using SmartInvest.Repositories;
using System.ComponentModel;

namespace SmartInvest.Services
{
    public class CuentaService
    {
        private readonly CuentaDBContext _cuentaDbContext;

        public CuentaService(CuentaDBContext cuentaDbContext)
        {
            _cuentaDbContext = cuentaDbContext;
        }   

        public async Task<List<CuentaDto>> Get()
        {
            return _cuentaDbContext.Get().Result.Select(c => c.ToDo()).ToList();
        } 

        public async Task<CuentaDto> Get(int id)
        {
            CuentaModel result = await _cuentaDbContext.Get(id);
            return result.ToDo();
        }

        public async Task<CuentaDto> Create(NewCuentaDto cuentaDto)
        {
            CuentaModel newCuenta = new CuentaModel
            {
                idUsuario = cuentaDto.idUsuario,
                saldo = cuentaDto.saldo
            };
            CuentaModel entity = await _cuentaDbContext.Create(newCuenta);
            return entity.ToDo();
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualBasic;
using SmartInvest.Models;
using SmartInvest.Services;

namespace SmartInvest.Repositories
{
    public class UsuarioDBContext : DbContext
    {
        public UsuarioDBContext(DbContextOptions<UsuarioDBContext> options)
            : base(options) { }

        public DbSet<UsuarioModel> Usuario { get; set; }


        public async Task<UsuarioModel> Get(int id)
        {
            return await Usuario.FirstAsync(x => x.idUsuario == id);
        }

        public async Task<UsuarioModel> Login(string correo, string password)
        {
            return await Usuario.FirstAsync(x => x.correo == correo && x.password == password);
        } 

        public async Task<List<UsuarioModel>> Get()
        {
            return await Usuario.ToListAsync();
        }

        public async Task<UsuarioModel> Create(UsuarioModel entity)
        {
            EntityEntry<UsuarioModel> response = await Usuario.AddAsync(entity);
            await SaveChangesAsync();
            return await Get(response.Entity.idUsuario);
        }

        public void Delete(int id)
        {
            UsuarioModel usuario = Usuario.FirstOrDefault(x => x.idUsuario == id);
            if (usuario != null)
            {
                Usuario.Remove(usuario);
                SaveChanges();
            }
        }

    }
}

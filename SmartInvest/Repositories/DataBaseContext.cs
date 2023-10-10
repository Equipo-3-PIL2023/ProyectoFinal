using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualBasic;
using SmartInvest.Models;

namespace SmartInvest.Repositories
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options) { }

        public DbSet<UserModel> Usuario { get; set; }


        public async Task<UserModel> Get(int id)
        {
            return await Usuario.FirstAsync(x => x.idUsuario == id);
        }

        public async Task<List<UserModel>> Get()
        {
            return await Usuario.ToListAsync();
        }

        public async Task<UserModel> Create(UserModel entity)
        {
            EntityEntry<UserModel> response = await Usuario.AddAsync(entity);
            await SaveChangesAsync();
            return await Get(response.Entity.idUsuario ?? throw new Exception("Error al guardar."));
        }

    }
}

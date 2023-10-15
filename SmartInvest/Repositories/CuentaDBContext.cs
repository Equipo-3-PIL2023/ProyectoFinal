using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmartInvest.Models;

namespace SmartInvest.Repositories
{
    public class CuentaDBContext : DbContext
    {
        public CuentaDBContext(DbContextOptions<CuentaDBContext>options) 
            :base(options){ }

        public DbSet<CuentaModel> Cuenta {  get; set; }

        public async Task<List<CuentaModel>> Get()
        {
            return await Cuenta.ToListAsync();
        }

        public async Task<CuentaModel> Get(int id)
        {
            return await Cuenta.FirstAsync(x => x.idCuenta == id);
        }

        public async Task<CuentaModel> Create(CuentaModel entity)
        {
            EntityEntry<CuentaModel> response = await Cuenta.AddAsync(entity);
            await SaveChangesAsync();
            return await Get(response.Entity.idCuenta);
        }
    }
}

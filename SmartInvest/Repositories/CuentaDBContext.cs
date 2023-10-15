using Microsoft.EntityFrameworkCore;
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
    }
}

using Microsoft.EntityFrameworkCore;
using SmartInvest.Models;

namespace SmartInvest.Repositories
{
    public class AccionDBContext : DbContext
    {
        public AccionDBContext(DbContextOptions<AccionDBContext>options)
            :base(options) { }

        public DbSet<AccionModel> Acciones {  get; set; }

        public async Task<List<AccionModel>> Get()
        {
            return await Acciones.ToListAsync();
        }
    }
}

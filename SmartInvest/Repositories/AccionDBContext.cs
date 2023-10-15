using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public async Task<AccionModel> Get(int id)
        {
            return await Acciones.FirstAsync(x => x.idAccion == id);
        }


        public async Task<AccionModel> Create(AccionModel entity)
        {
            EntityEntry<AccionModel> response = await Acciones.AddAsync(entity);
            await SaveChangesAsync();
            return await Get(response.Entity.idAccion);
        }
    }
}

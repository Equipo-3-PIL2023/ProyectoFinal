using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmartInvest.Models;

namespace SmartInvest.Repositories
{
    public class TransaccionDBContext : DbContext
    {
        public TransaccionDBContext(DbContextOptions<TransaccionDBContext> options) 
            : base(options) { }

        public DbSet<TransaccionModel> Transaccion { get; set; }

        public async Task<List<TransaccionModel>> Get()
        {
            return await Transaccion.ToListAsync();
        }

        public async Task<TransaccionModel> Get(int id)
        {
            return await Transaccion.FirstAsync(x => x.idTransaccion == id);
        }

        public async Task<TransaccionModel> Create(TransaccionModel entity)
        {
            EntityEntry<TransaccionModel> response = await Transaccion.AddAsync(entity);
            await SaveChangesAsync();
            return await Get(response.Entity.idTransaccion);
        }

        public void Delete(int id)
        {
            TransaccionModel transaccion = Transaccion.FirstOrDefault(x => x.idTransaccion == id);
            if (transaccion != null)
            {
                Transaccion.Remove(transaccion);
                SaveChanges();
            }
        }
    }       
}

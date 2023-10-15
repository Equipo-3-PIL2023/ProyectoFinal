using Microsoft.EntityFrameworkCore;
using SmartInvest.Models;

namespace SmartInvest.Repositories
{
    public class TransaccionDBContext : DbContext
    {
        public TransaccionDBContext(DbContextOptions<TransaccionDBContext> options) 
            : base(options) { }

        public DbSet<TransaccionModel> Transaccion { get; set; }


    }       
}

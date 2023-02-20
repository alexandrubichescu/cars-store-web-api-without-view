using Microsoft.EntityFrameworkCore;
#nullable disable
namespace CarsStore.Data
{
    public class CarStoreContext : DbContext
    {
        public CarStoreContext(DbContextOptions<CarStoreContext> options): base (options)
        {
        }
        public DbSet<Cars> Cars { get; set; } 
    }
}

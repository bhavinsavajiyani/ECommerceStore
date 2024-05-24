using EComm_Store_Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EComm_Store_Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options) {}

        public DbSet<Product> Products { get; set; }
    }
}
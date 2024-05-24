using EComm_Store_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace EComm_Store_API.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options) {}

        public DbSet<Product> Products { get; set; }
    }
}
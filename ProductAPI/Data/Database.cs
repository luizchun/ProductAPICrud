using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Data
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

    }
}

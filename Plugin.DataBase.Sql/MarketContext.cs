using Core;
using Microsoft.EntityFrameworkCore;

namespace Plugin.DataBase.Sql
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions<MarketContext> options): base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using pool_api.DomainModels;

namespace pool_api.AppData
{
    public class AppDataDbContext : DbContext
    {
        public DbSet<Measuring> Measurings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database/pool-api.db");
        }
    }
}
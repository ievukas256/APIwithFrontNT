using Microsoft.EntityFrameworkCore;

namespace APIwithFrontNT.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<House> Houses {get; set;}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models;

namespace Net14Web.DbStuff
{
    public class WebDbContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Weapon> Weapons { get; set; }

        public WebDbContext(DbContextOptions options) : base(options) { }
    }
}

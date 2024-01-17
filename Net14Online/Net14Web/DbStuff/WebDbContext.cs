using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Models.Movies;

namespace Net14Web.DbStuff
{
    public class WebDbContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }
        
        public DbSet<Weapon> Weapons { get; set; }

        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public WebDbContext(DbContextOptions options) : base(options) { }
    }
}

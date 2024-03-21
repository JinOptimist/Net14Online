using Microsoft.EntityFrameworkCore;
using CommentMoviesMicroService.DbStuff.Model;

namespace CommentMoviesMicroService.DbStuff
{
    public class CommentWebDbContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }

        public CommentWebDbContext(DbContextOptions<CommentWebDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

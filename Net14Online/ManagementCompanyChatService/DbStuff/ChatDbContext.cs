using ManagementCompanyChatService.DbStuff.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementCompanyChatService.DbStuff
{
    public class ChatDbContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }

        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

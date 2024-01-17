using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.ManagmentCompany.Models;

namespace Net14Web.DbStuff
{
    public class ManagmentCompanyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }

        public ManagmentCompanyDbContext(DbContextOptions options) : base(options) { }
    }
}

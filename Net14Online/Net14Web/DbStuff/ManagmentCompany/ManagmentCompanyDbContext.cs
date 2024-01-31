using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.ManagmentCompany.Models;

namespace Net14Web.DbStuff
{
    public class ManagmentCompanyDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserTask> UserTasks { get; set; }

        public DbSet<MemberPermission> MemberPermissions { get; set; }

        public DbSet<MemberStatus> MemberStatuses { get; set; }

        public DbSet<UserTaskStatus> TaskStatuses { get; set; }

        public ManagmentCompanyDbContext(DbContextOptions<ManagmentCompanyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<UserTask>()
                .HasOne(user => user.Author)
                .WithMany(task => task.UserCreatedTasks)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Entity<UserTask>()
                .HasOne(user => user.Executor)
                .WithMany(task => task.UserExecutedTasks)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

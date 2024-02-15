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
                .Entity<Company>()
                .HasMany(c => c.Projects)
                .WithOne(p => p.Company)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Entity<Company>()
                .HasMany(c => c.Executors)
                .WithOne(e => e.Company)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Entity<Company>()
                .HasOne(c => c.Status)
                .WithMany(e => e.Companies)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Entity<Project>()
                .HasOne(p => p.Company)
                .WithMany(c => c.Projects)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Entity<Project>()
                .HasMany(p => p.Executors)
                .WithMany(c => c.Projects);

            builder
                .Entity<User>()
                .HasMany(u => u.Projects)
                .WithMany(p => p.Executors);

            builder
                .Entity<User>()
                .HasOne(u => u.Company)
                .WithMany(p => p.Executors)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Entity<MemberStatus>()
                .HasMany(ms => ms.Companies)
                .WithOne(c => c.Status)
                .OnDelete(DeleteBehavior.NoAction);

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

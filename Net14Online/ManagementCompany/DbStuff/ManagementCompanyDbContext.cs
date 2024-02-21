using Microsoft.EntityFrameworkCore;
using ManagementCompany.DbStuff.Models;

namespace ManagementCompany.DbStuff
{
    public class ManagementCompanyDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserTask> UserTasks { get; set; }

        public DbSet<MemberPermission> MemberPermissions { get; set; }

        public DbSet<MemberStatus> MemberStatuses { get; set; }

        public DbSet<UserTaskStatus> TaskStatuses { get; set; }

        public ManagementCompanyDbContext(DbContextOptions<ManagementCompanyDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            #region Company
            builder
                .Entity<Company>()
                .HasIndex(c => c.ShortName)
                .IsUnique();

            builder
                .Entity<Company>()
                .HasIndex(c => c.Email)
                .IsUnique();

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
            #endregion
            #region Permission
            builder
                .Entity<MemberPermission>()
                .HasIndex(mp => mp.Permission)
                .IsUnique();
            #endregion
            #region Status
            builder
                .Entity<MemberStatus>()
                .HasMany(ms => ms.Companies)
                .WithOne(c => c.Status)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Entity<MemberStatus>()
                .HasIndex(ms => ms.Status)
                .IsUnique();
            #endregion
            #region Project
            builder
                .Entity<Project>()
                .HasIndex(p => p.ShortName)
                .IsUnique();

            builder
                .Entity<Project>()
                .HasOne(p => p.Company)
                .WithMany(c => c.Projects)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Entity<Project>()
                .HasMany(p => p.Executors)
                .WithMany(c => c.Projects);
            #endregion
            #region User
            builder
                .Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder
                .Entity<User>()
                .HasMany(u => u.Projects)
                .WithMany(p => p.Executors);

            builder
                .Entity<User>()
                .HasOne(u => u.Company)
                .WithMany(p => p.Executors)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
            #region Task
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
            #endregion
            #region TaskStatus
            builder
                .Entity<UserTaskStatus>()
                .HasIndex(uts => uts.Status)
                .IsUnique();
            #endregion
        }
    }
}

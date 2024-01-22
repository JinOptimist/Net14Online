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

        public DbSet<Executor> Executors { get; set; }

        public DbSet<MemberPermission> MemberPermissions { get; set; }

        public DbSet<MemberStatus> MemberStatuses { get; set; }

        public DbSet<UserTaskStatus> TaskStatuses { get; set; }

        public ManagmentCompanyDbContext(DbContextOptions options) : base(options) { }
    }
}

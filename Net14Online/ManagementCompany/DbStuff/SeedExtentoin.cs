using ManagementCompany.DbStuff.Models;
using ManagementCompany.DbStuff.Repositories;

namespace ManagementCompany.DbStuff
{
    public static class SeedExtentoin
    {
        public static void Seed(WebApplication app)
        {
            using (var serviceScope = app.Services.CreateScope())
            {
                SeedMcUser(serviceScope.ServiceProvider);
                SeedStatus(serviceScope.ServiceProvider);
                SeedPermission(serviceScope.ServiceProvider);
            }
        }

        private static MemberStatus SeedStatus(IServiceProvider di)
        {
            var statusRepository = di.GetService<MemberStatusRepository>();

            var status = new MemberStatus();

            if (statusRepository.Any() == false)
            {
                status.Status = "Active";

                statusRepository.Add(status);
            }

            return status;
        }

        private static MemberPermission SeedPermission(IServiceProvider di)
        {
            var permissionRepository = di.GetService<MemberPermissionRepository>();

            var permission = new MemberPermission();

            if (permissionRepository.Any() == false)
            {
                permission.Permission = "SuperAdmin";

                permissionRepository.Add(permission);
            }

            return permission;
        }

        private static void SeedMcUser(IServiceProvider di)
        {
            var userRepository = di.GetService<UserRepository>();
            if (userRepository.Any() == false)
            {
                var admin = new User
                {
                    NickName = "Admin",
                    Email = "Admin",
                    Password = "Admin",
                    Status = SeedStatus(di),
                    MemberPermission = SeedPermission(di)
                };
                userRepository.Add(admin);
            }
        }
    }
}

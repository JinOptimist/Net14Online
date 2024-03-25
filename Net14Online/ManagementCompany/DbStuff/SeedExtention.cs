using ManagementCompany.DbStuff.Models;
using ManagementCompany.DbStuff.Models.Enums;
using ManagementCompany.DbStuff.Repositories;

namespace ManagementCompany.DbStuff
{
    public static class SeedExtention
    {
        public static void Seed(WebApplication app)
        {
            using (var serviceScope = app.Services.CreateScope())
            {
                SeedStatus(serviceScope.ServiceProvider);
                SeedPermission(serviceScope.ServiceProvider);
                SeedUser(serviceScope.ServiceProvider);
            }
        }

        private static void SeedStatus(IServiceProvider di)
        {
            var statusRepository = di.GetService<MemberStatusRepository>();

            if (statusRepository.Any() == false)
            {
                foreach (string memberStatus in Enum.GetNames(typeof(MemberStatusEnum)))
                {
                    var status = new MemberStatus();
                    status.Status = memberStatus;

                    statusRepository.Add(status);
                }
            }
        }

        private static void SeedPermission(IServiceProvider di)
        {
            var permissionRepository = di.GetService<MemberPermissionRepository>();

            if (permissionRepository.Any() == false)
            {
                foreach (string memberPermission in Enum.GetNames(typeof(MemberPermissionEnum)))
                {
                    var permission = new MemberPermission();
                    permission.Permission = memberPermission;

                    permissionRepository.Add(permission);
                }
            }
        }

        private static void SeedUser(IServiceProvider di)
        {
            var statusRepository = di.GetService<MemberStatusRepository>();
            var permissionRepository = di.GetService<MemberPermissionRepository>();
            var userRepository = di.GetService<UserRepository>();

            if (userRepository.Any() == false)
            {
                var superAdmin = new User
                {
                    NickName = "SuperAdmin",
                    Email = "SuperAdmin",
                    Password = "SuperAdmin",
                    Status = statusRepository?.GetById((int)MemberStatusEnum.Active),
                    MemberPermission = permissionRepository?.GetById((int)MemberPermissionEnum.SuperAdmin)
                };
                userRepository.Add(superAdmin);

                var admin = new User
                {
                    NickName = "Admin",
                    Email = "Admin",
                    Password = "Admin",
                    Status = statusRepository?.GetById((int)MemberStatusEnum.Active),
                    MemberPermission = permissionRepository?.GetById((int)MemberPermissionEnum.Admin)
                };
                userRepository.Add(admin);

                var user = new User
                {
                    NickName = "User",
                    Email = "User",
                    Password = "User",
                    Status = statusRepository?.GetById((int)MemberStatusEnum.Active),
                    MemberPermission = permissionRepository?.GetById((int)MemberPermissionEnum.User)
                };
                userRepository.Add(user);
            }
        }
    }
}

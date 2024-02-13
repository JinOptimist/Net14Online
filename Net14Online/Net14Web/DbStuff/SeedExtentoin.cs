using Net14Web.DbStuff.ManagmentCompany.Models;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Repositories;
using Net14Web.DbStuff.Repositories.Movies;
using Net14Web.Services.RealEstate;
using System.Security;

namespace Net14Web.DbStuff
{
    public static class SeedExtentoin
    {
        public const string ADD_COMMENT_TO_MOVIE = "ADD_COMMENT_TO_MOVIE";
        public const string DELETE_COMMENT_ON_MOVIE = "DELETE_COMMENT_ON_MOVIE";
        public const string EDIT_COMMENT_ON_MOVIE = "EDIT_COMMENT_ON_MOVIE";
        public const string ACCESS_TO_ADMIN_PANEL = "ACCESS_TO_ADMIN_PANEL";
        public const string ADD_MOVIE = "ADD_MOVIE";
        public const string DELETE_MOVIE = "DELETE_MOVIE";
        public const string EDIT_MOVIE = "EDIT_MOVIE";
        public const string DELETE_USER = "DELETE_USER";
        public const string EDIT_USER = "EDIT_USER";
        public const string ADMIN_ROLE = "Admin";
        public const string MODERATOR_ROLE = "Moderator";
        public const string USER_ROLE = "User";

        public static void Seed(WebApplication app)
        {
            using (var serviceScope = app.Services.CreateScope())
            {
                SeedHeroes(serviceScope.ServiceProvider);
                SeedWeapon(serviceScope.ServiceProvider);
                SeedUser(serviceScope.ServiceProvider);
                SeedRole(serviceScope.ServiceProvider);
                SeedRolePermissions(serviceScope.ServiceProvider);
                SeedAddPermissionToRoles(serviceScope.ServiceProvider);

                // Seed ManagmentCompany database
                SeedMcUser(serviceScope.ServiceProvider);
                SeedStatus(serviceScope.ServiceProvider);
                SeedPermission(serviceScope.ServiceProvider);
            }
        }

        private static void SeedUser(IServiceProvider serviceProvider)
        {
            var userRepository = serviceProvider.GetService<UserRepository>();
            if (!userRepository.AnyUserWithName("admin"))
            {
                var admin = new DbStuff.Models.Movies.User()
                {
                    Login = "admin",
                    Password = "123",
                    Email = "test@test.com",
                };

                userRepository.Add(admin);
            }

            if (!userRepository.AnyUserWithName("user"))
            {
                var user = new DbStuff.Models.Movies.User()
                {
                    Login = "user",
                    Password = "123",
                    Email = "test@test.com",
                };

                userRepository.Add(user);
            }

            if (!userRepository.AnyUserWithName("superAdmin"))
            {
                var user = new DbStuff.Models.Movies.User()
                {
                    Login = "superAdmin",
                    Password = "123",
                    Email = "test@test.com",
                    Role = GetRole(serviceProvider, "admin")
                };

                userRepository.Add(user);
            }
        }

        private static void SeedHeroes(IServiceProvider di)
        {
            var heroRepository = di.GetService<HeroRepository>();
            if (!heroRepository.Any())
            {
                var orc = new Hero
                {
                    Hp = 50,
                    Coins = 1,
                    Name = "Orc Вася",
                    AvatarUrl = "",
                    Birthday = DateTime.Now,
                    Race = Models.Enums.Race.Orc
                };
                heroRepository.Add(orc);

                var elf = new Hero
                {
                    Hp = 10,
                    Coins = 100,
                    Name = "Эльфийка Света",
                    AvatarUrl = "",
                    Birthday = DateTime.Now,
                    Race = Models.Enums.Race.Elf
                };
                heroRepository.Add(elf);
            }
        }

        private static void SeedWeapon(IServiceProvider di)
        {
            var weaponRepository = di.GetService<WeaponRepository>();
            if (!weaponRepository.Any())
            {
                var knife = new Weapon
                {
                    Damage = 3,
                    Name = "Кинжал"
                };
                weaponRepository.Add(knife);

                var sword = new Weapon
                {
                    Name = "Меч",
                    Damage = 10
                };
                weaponRepository.Add(sword);
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

        private static void SeedRole(IServiceProvider di)
        {
            var roleRepository = di.GetService<RoleRepository>();
            if (roleRepository.Any() == false)
            {
                var role = new Models.Role
                {
                    Name = ADMIN_ROLE
                };
                roleRepository.Add(role);

                role = new Models.Role
                {
                    Name = MODERATOR_ROLE
                };
                roleRepository.Add(role);

                role = new Models.Role
                {
                    Name = USER_ROLE
                };
                roleRepository.Add(role);
            }
        }

        private static Role GetRole(IServiceProvider di, string roleName)
        {
            var roleRepository = di.GetService<RoleRepository>();
            var role = roleRepository.GetRoleByName(roleName);
            return role;
        }

        private static void SeedRolePermissions(IServiceProvider di)
        {
            var permissionRepository = di.GetService<PermissionRepository>();

            if (permissionRepository.GetPermissionByName(ADD_COMMENT_TO_MOVIE) is null)
            {
                AddPermission(permissionRepository, ADD_COMMENT_TO_MOVIE);
            }

            if (permissionRepository.GetPermissionByName(DELETE_COMMENT_ON_MOVIE) is null)
            {
                AddPermission(permissionRepository, DELETE_COMMENT_ON_MOVIE);
            }

            if (permissionRepository.GetPermissionByName(EDIT_COMMENT_ON_MOVIE) is null)
            {
                AddPermission(permissionRepository, EDIT_COMMENT_ON_MOVIE);
            }

            if (permissionRepository.GetPermissionByName(ADD_MOVIE) is null)
            {
                AddPermission(permissionRepository, ADD_MOVIE);
            }

            if (permissionRepository.GetPermissionByName(EDIT_MOVIE) is null)
            {
                AddPermission(permissionRepository, EDIT_MOVIE);
            }

            if (permissionRepository.GetPermissionByName(EDIT_USER) is null)
            {
                AddPermission(permissionRepository, EDIT_USER);
            }

            if (permissionRepository.GetPermissionByName(DELETE_MOVIE) is null)
            {
                AddPermission(permissionRepository, DELETE_MOVIE);
            }

            if (permissionRepository.GetPermissionByName(DELETE_USER) is null)
            {
                AddPermission(permissionRepository, DELETE_USER);
            }

            if (permissionRepository.GetPermissionByName(ACCESS_TO_ADMIN_PANEL) is null)
            {
                AddPermission(permissionRepository, ACCESS_TO_ADMIN_PANEL);
            }
        }

        private static void AddPermission(PermissionRepository permissionRepository, string permissionName)
        {
            var permission = new Permission
            {
                Name = permissionName
            };
            permissionRepository.Add(permission);
        }

        private static void SeedAddPermissionToRoles(IServiceProvider di)
        {
            var permissionRepository = di.GetService<PermissionRepository>();
            var roleRepository = di.GetService<RoleRepository>();

            var admin = roleRepository.GetRoleByName(ADMIN_ROLE);
            permissionRepository.AddRoleToPermission(admin, ADD_COMMENT_TO_MOVIE);
            permissionRepository.AddRoleToPermission(admin, DELETE_COMMENT_ON_MOVIE);
            permissionRepository.AddRoleToPermission(admin, EDIT_COMMENT_ON_MOVIE);
            permissionRepository.AddRoleToPermission(admin, ADD_MOVIE);
            permissionRepository.AddRoleToPermission(admin, EDIT_MOVIE);
            permissionRepository.AddRoleToPermission(admin, DELETE_MOVIE);
            permissionRepository.AddRoleToPermission(admin, EDIT_USER);
            permissionRepository.AddRoleToPermission(admin, DELETE_USER);
            permissionRepository.AddRoleToPermission(admin, ACCESS_TO_ADMIN_PANEL);

            var moderator = roleRepository.GetRoleByName(MODERATOR_ROLE);
            permissionRepository.AddRoleToPermission(moderator, ADD_COMMENT_TO_MOVIE);
            permissionRepository.AddRoleToPermission(moderator, DELETE_COMMENT_ON_MOVIE);
            permissionRepository.AddRoleToPermission(moderator, EDIT_COMMENT_ON_MOVIE);
            permissionRepository.AddRoleToPermission(moderator, ADD_MOVIE);
            permissionRepository.AddRoleToPermission(moderator, EDIT_MOVIE);
            permissionRepository.AddRoleToPermission(moderator, ACCESS_TO_ADMIN_PANEL);

            var user = roleRepository.GetRoleByName(USER_ROLE);
            permissionRepository.AddRoleToPermission(user, ADD_COMMENT_TO_MOVIE);
            permissionRepository.AddRoleToPermission(user, DELETE_COMMENT_ON_MOVIE);
            permissionRepository.AddRoleToPermission(user, EDIT_COMMENT_ON_MOVIE);
        }

        private static void SeedMcUser(IServiceProvider di)
        {
            var userRepository = di.GetService<McUserRepository>();
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

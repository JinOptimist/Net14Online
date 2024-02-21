using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Repositories;
using Net14Web.DbStuff.Repositories.Movies;

namespace Net14Web.DbStuff
{
    public static class SeedExtentoin
    {
        public const string ADMIN_ROLE = "Admin";
        public const string MODERATOR_ROLE = "Moderator";
        public const string USER_ROLE = "User";

        public static void Seed(WebApplication app)
        {
            using (var serviceScope = app.Services.CreateScope())
            {
                SeedHeroes(serviceScope.ServiceProvider);
                SeedWeapon(serviceScope.ServiceProvider);
                SeedRole(serviceScope.ServiceProvider);
                SeedRolePermissions(serviceScope.ServiceProvider);
                SeedAddPermissionToRoles(serviceScope.ServiceProvider);
                SeedUser(serviceScope.ServiceProvider);
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
                    Roles = new List<Role> { GetRole(serviceProvider, "admin") }
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
                    Roles = new List<Role> { GetRole(serviceProvider, "user") }
                };

                userRepository.Add(user);
            }

            if (!userRepository.AnyUserWithName("moderator"))
            {
                var user = new DbStuff.Models.Movies.User()
                {
                    Login = "moderator",
                    Password = "123",
                    Email = "test@test.com",
                    Roles = new List<Role> { GetRole(serviceProvider, "moderator") }
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
            List<PermissionType> permissionTypes = new List<PermissionType>
            {
                PermissionType.AddCommentToMovie,
                PermissionType.DeleteCommentOnMovie,
                PermissionType.EditCommentOnMovie,
                PermissionType.AccessToAdminPanel,
                PermissionType.AddMovie,
                PermissionType.DeleteMovie,
                PermissionType.DeleteUser,
                PermissionType.EditMovie,
                PermissionType.EditUser
            };
            var permissionsInDb = permissionRepository.GetAll();
            var missingPermissions = permissionTypes.Where(p => permissionsInDb.Any(pR => pR.Type == p) == false);
            foreach (var missingPermission in missingPermissions)
            {
                var permission = new Permission
                {
                    Type = missingPermission
                };
                permissionRepository.Add(permission);
            }
        }

        private static void SeedAddPermissionToRoles(IServiceProvider di)
        {
            var permissionRepository = di.GetService<PermissionRepository>();
            var roleRepository = di.GetService<RoleRepository>();

            List<PermissionType> userPermissions = new List<PermissionType>
            {
                PermissionType.AddCommentToMovie,
                PermissionType.DeleteCommentOnMovie,
                PermissionType.EditCommentOnMovie
            };
            List<PermissionType> moderatorPermissions = new List<PermissionType>(userPermissions)
            {
                PermissionType.AddMovie,
                PermissionType.EditMovie,
                PermissionType.AccessToAdminPanel
            };
            List<PermissionType> adminPermissions = new List<PermissionType>(moderatorPermissions)
            {
                PermissionType.DeleteMovie,
                PermissionType.EditUser,
                PermissionType.DeleteUser
            };

            var user = roleRepository.GetRoleByName(USER_ROLE);
            AddPermissionToRole(user, userPermissions, roleRepository, permissionRepository);
            var moderator = roleRepository.GetRoleByName(MODERATOR_ROLE);
            AddPermissionToRole(moderator, moderatorPermissions, roleRepository, permissionRepository);
            var admin = roleRepository.GetRoleByName(ADMIN_ROLE);
            AddPermissionToRole(admin, adminPermissions, roleRepository, permissionRepository);
        }

        private static void AddPermissionToRole(Role role, List<PermissionType> permissions, RoleRepository roleRepository, PermissionRepository permissionRepository)
        {
            foreach (var aPerm in permissions)
            {
                var permission = permissionRepository.GetPermissionByType(aPerm);
                roleRepository.AddPermissionToRole(permission, role);
            }
        }
    }
}

using Net14Web.DbStuff.ManagmentCompany.Models;
using Net14Web.DbStuff.ManagmentCompany.Models.Enums;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Repositories;
using Net14Web.DbStuff.Repositories.ManagmentCompany;
using Net14Web.DbStuff.Repositories.Movies;

namespace Net14Web.DbStuff
{
    public static class SeedExtentoin
    {
        public static void Seed(WebApplication app)
        {
            using (var serviceScope = app.Services.CreateScope())
            {
                SeedHeroes(serviceScope.ServiceProvider);
                SeedWeapon(serviceScope.ServiceProvider);
                SeedUser(serviceScope.ServiceProvider);

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

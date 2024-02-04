using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Repositories;

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
    }
}

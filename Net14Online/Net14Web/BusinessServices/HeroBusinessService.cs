using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Repositories;
using Net14Web.Models.Dnd;
using Net14Web.Services;
using Net14Web.Services.DndServices;

namespace Net14Web.BusinessServices
{
    public class HeroBusinessService
    {
        public HeroRepository _heroRepository;
        public HeroPermissions _heroPermissions;
        public AuthService _authService;


        public HeroBusinessService(HeroRepository heroRepository, HeroPermissions heroPermissions, AuthService authService)
        {
            _heroRepository = heroRepository;
            _heroPermissions = heroPermissions;
            _authService = authService;
        }

        public List<HeroViewModel> GetHeroesForMainPage()
        {
            var dbHeroes = _heroRepository.GetHeroesWithWeaponAndOwner(5);
            var viewModels = dbHeroes
                .Select(dbHero =>
                {
                    return new HeroViewModel
                    {
                        Id = dbHero.Id,
                        Age = DateTime.Now.Year - dbHero.Birthday.Year,
                        Name = dbHero.Name,
                        Coins = dbHero.Coins,
                        Race = dbHero.Race,
                        AvatarUrl = dbHero.AvatarUrl,
                        FavWeaponName = dbHero.FavoriteWeapon?.Name ?? "---",
                        OwnerName = dbHero.Owner?.Login ?? "Неизвестен",
                        CanDelete = _heroPermissions.CanDelete(dbHero),
                    };
                })
                .ToList();

            return viewModels;
        }

        public int AddHero(AddHeroViewModel heroViewModel)
        {
            var hero = new Hero
            {
                Name = heroViewModel.Name,
                Birthday = DateTime.Now,
                Coins = heroViewModel.Coins ?? default,
                Race = heroViewModel.Race,
                AvatarUrl = heroViewModel.AvatarUrl ?? "default.jpg",
                Owner = _authService.GetCurrentUser()
            };

            return _heroRepository.Add(hero);
        }
    }
}

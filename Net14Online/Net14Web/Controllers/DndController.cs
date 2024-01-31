using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Repositories;
using Net14Web.Models.Dnd;
using Net14Web.Services.DndServices;
using System.Xml.Linq;

namespace Net14Web.Controllers
{
    public class DndController : Controller
    {
        private readonly HeroBuilder _heroBuilder;
        private HeroRepository _heroRepository;
        private WeaponRepository _weaponRepository;

        /// <summary>
        /// TEMP SOLUTION. DONT DO THIS IN PRODUCT
        /// </summary>
        public static List<HeroViewModel> heroViewModels = new List<HeroViewModel>();

        public DndController(HeroBuilder heroBuilder, 
            HeroRepository heroRepository, 
            WeaponRepository weaponRepository)
        {
            _heroBuilder = heroBuilder;
            _heroRepository = heroRepository;
            _weaponRepository = weaponRepository;
        }

        public IActionResult Index()
        {
            var dbHeroes = _heroRepository.GetHeroesWithWeapon(10);
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
                        FavWeaponName = dbHero.FavoriteWeapon?.Name ?? "---"
                    };
                })
                .ToList();

            var dndIndexViewModel = new DndIndexViewModel()
            {
                Heroes = viewModels,
                Weapons = new List<WeaponViewModel> { new WeaponViewModel { Name = "Кинжал", Damadge = 3 } }
            };

            return View(dndIndexViewModel);
        }

        public IActionResult Profile(int heroId)
        {
            var hero = _heroRepository.GetById(heroId);
            var viewModel = new HeroViewModel();
            viewModel.Id = heroId;
            viewModel.AvatarUrl = hero.AvatarUrl;
            viewModel.Name = hero.Name;
            viewModel.Coins = hero.Coins;
            viewModel.Race = hero.Race;

            return View(viewModel);
        }

        public IActionResult Remove(int id)
        {
            _heroRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult AddRandomHero()
        {
            var hero = _heroBuilder.BuildRandomHero();
            heroViewModels.Add(hero);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateCoin(int heroId, int coin)
        {
            _heroRepository.UpdateCoin(heroId, coin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddHero()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddHero(AddHeroViewModel heroViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(heroViewModel);
            }

            var hero = new Hero
            {
                Name = heroViewModel.Name,
                Birthday = DateTime.Now,
                Coins = heroViewModel.Coin ?? default,
                Race = heroViewModel.Race
            };

            _heroRepository.Add(hero);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ChooseFavoriteWeapon()
        {
            var viewModel = new FavoriteWeaponViewModel();

            viewModel.Heroes = _heroRepository
                .GetAll()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            viewModel.Weapons = _weaponRepository
                .GetAll()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ChooseFavoriteWeapon(int heroId, int weaponId)
        {
            _heroRepository.SetFavoriteWeapone(heroId, weaponId);

            return RedirectToAction("Index");
        }
    }
}

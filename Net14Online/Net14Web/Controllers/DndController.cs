
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models;
using Net14Web.Models.Dnd;
using Net14Web.Services.DndServices;
using System.Xml.Linq;

namespace Net14Web.Controllers
{
    public class DndController : Controller
    {
        private readonly HeroBuilder _heroBuilder;
        private WebDbContext _webDbContext;

        /// <summary>
        /// TEMP SOLUTION. DONT DO THIS IN PRODUCT
        /// </summary>
        public static List<HeroViewModel> heroViewModels = new List<HeroViewModel>();

        public DndController(HeroBuilder heroBuilder, WebDbContext webDbContext)
        {
            _heroBuilder = heroBuilder;
            _webDbContext = webDbContext;
        }

        public IActionResult Index()
        {
            var dbHeroes = _webDbContext
                .Heroes
                //.Include(x => x.FavoriteWeapon)
                .Take(10)
                .ToList();

            var viewModels = dbHeroes
                .Select(dbHero =>
                {
                    return new HeroViewModel
                    {
                        Id = dbHero.Id,
                        Age = DateTime.Now.Year - dbHero.Birthday.Year,
                        Name = dbHero.Name,
                        Coins = dbHero.Coins,
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

        public IActionResult Profile()
        {
            var viewModel = new HeroViewModel();

            viewModel.Name = "Test";
            viewModel.Coins = DateTime.Now.Second;
            viewModel.Tools = new List<string> { "Hammer", "Shuffle" };

            return View(viewModel);
        }

        public IActionResult Remove(int id)
        {
            var hero = _webDbContext.Heroes.First(x => x.Id == id);
            _webDbContext.Heroes.Remove(hero);
            _webDbContext.SaveChanges();

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
            var hero = _webDbContext.Heroes.First(x => x.Id == heroId);
            hero.Coins = coin;
            _webDbContext.SaveChanges();

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
                Coins = heroViewModel.Coin ?? default
            };

            _webDbContext.Heroes.Add(hero);

            _webDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ChooseFavoriteWeapon()
        {
            var viewModel = new FavoriteWeaponViewModel();

            viewModel.Heroes = _webDbContext
                .Heroes
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            viewModel.Weapons = _webDbContext
                .Weapons
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ChooseFavoriteWeapon(int heroId, int weaponId)
        {
            var hero = _webDbContext.Heroes.First(x => x.Id == heroId);
            var weapon = _webDbContext.Weapons.First(x => x.Id == weaponId);
            hero.FavoriteWeapon = weapon;
            _webDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

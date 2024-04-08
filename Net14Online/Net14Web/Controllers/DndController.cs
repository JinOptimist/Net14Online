using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Net14Web.BusinessServices;
using Net14Web.Controllers.CustomAuthAttributes;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Repositories;
using Net14Web.LocalizationFiles;
using Net14Web.Models.Dnd;
using Net14Web.Services;
using Net14Web.Services.DndServices;

namespace Net14Web.Controllers
{
    public class DndController : Controller
    {
        private HeroRepository _heroRepository;
        private WeaponRepository _weaponRepository;
        private AuthService _authService;
        private HeroPermissions _heroPermissions;
        private HeroBusinessService _heroBusinessService;

        public DndController(HeroRepository heroRepository,
            WeaponRepository weaponRepository,
            AuthService authService,
            HeroPermissions heroPermissions,
            HeroBusinessService heroBusinessService)
        {
            _heroRepository = heroRepository;
            _weaponRepository = weaponRepository;
            _authService = authService;
            _heroPermissions = heroPermissions;
            _heroBusinessService = heroBusinessService;
        }

        public IActionResult Index(int page = 1, int perPage = 5)
        {
            var userName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "name")?.Value ?? "Гость";

            var paginatorViewModel = _heroBusinessService.GetHeroesForMainPage(page, perPage);

            var dndIndexViewModel = new DndIndexViewModel()
            {
                PaginatorViewModel = paginatorViewModel,
                Weapons = new List<WeaponViewModel> { new WeaponViewModel { Name = "Кинжал", Damadge = 3 } },
                UserName = userName,
                CanChooseFavoriteWeapon = _heroPermissions.CanChooseFavoriteWeapon(),
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

        public IActionResult UpdateAvatar(int heroId, IFormFile avatar)
        {
            _heroBusinessService.UpdateAvatar(heroId, avatar);
            return RedirectToAction("Profile", new { heroId });
        }

        public IActionResult Remove(int id)
        {
            var dbHero = _heroRepository.GetByIdWithOwner(id);
            if (!_heroPermissions.CanDelete(dbHero))
            {
                throw new Exception("You haven't access");
            }
            
            _heroRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [AdminOnly]
        public IActionResult AddRandomHero()
        {
            var hero = new Hero
            {
                Name = "Random",
                Birthday = DateTime.Now,
                Coins = 5,
                Race = DbStuff.Models.Enums.Race.Human,
                AvatarUrl = "default.jpg",
                Owner = _authService.GetCurrentUser()
            };

            _heroRepository.Add(hero);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateCoin(int heroId, int coin)
        {
            _heroRepository.UpdateCoin(heroId, coin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddHero()
        {
            var viewModel = new AddHeroViewModel();
            viewModel.UserName = _authService.GetCurrentUserName();
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddHero(AddHeroViewModel heroViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(heroViewModel);
            }

            _heroBusinessService.AddHero(heroViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [DungeonMaster]
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
        [DungeonMaster]
        public IActionResult ChooseFavoriteWeapon(int heroId, int weaponId)
        {
            _heroRepository.SetFavoriteWeapone(heroId, weaponId);

            return RedirectToAction("Index");
        }
    }
}

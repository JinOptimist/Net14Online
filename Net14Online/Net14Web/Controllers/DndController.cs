using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Net14Web.Controllers.CustomAuthAttributes;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Repositories;
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

        private IWebHostEnvironment _webHostEnvironment;

        public DndController(HeroRepository heroRepository,
            WeaponRepository weaponRepository,
            IWebHostEnvironment webHostEnvironment,
            AuthService authService,
            HeroPermissions heroPermissions)
        {
            _heroRepository = heroRepository;
            _weaponRepository = weaponRepository;
            _webHostEnvironment = webHostEnvironment;
            _authService = authService;
            _heroPermissions = heroPermissions;
        }

        public IActionResult Index()
        {
            var userName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "name")?.Value ?? "Гость";

            var dbHeroes = _heroRepository.GetHeroesWithWeaponAndOwner(10);
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

            var dndIndexViewModel = new DndIndexViewModel()
            {
                Heroes = viewModels,
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
            // upload image
            var extension = Path.GetExtension(avatar.FileName);

            var fileName = $"heroAvatar{heroId}{extension}";
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "dndAvatars", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                avatar.CopyTo(fileStream);
            }

            var avatarUrl = $"/images/dndAvatars/{fileName}";
            _heroRepository.UpdateAvatar(heroId, avatarUrl);

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

            var hero = new Hero
            {
                Name = heroViewModel.Name,
                Birthday = DateTime.Now,
                Coins = heroViewModel.Coin ?? default,
                Race = heroViewModel.Race,
                AvatarUrl = heroViewModel.AvatarUrl ?? "default.jpg",
                Owner = _authService.GetCurrentUser()
            };

            _heroRepository.Add(hero);

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

using Microsoft.AspNetCore.Hosting;
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
        private IWebHostEnvironment _webHostEnvironment;


        public HeroBusinessService(HeroRepository heroRepository,
            HeroPermissions heroPermissions,
            AuthService authService,
            IWebHostEnvironment webHostEnvironment)
        {
            _heroRepository = heroRepository;
            _heroPermissions = heroPermissions;
            _authService = authService;
            _webHostEnvironment = webHostEnvironment;
        }

        public PaginatorViewModel<HeroViewModel> GetHeroesForMainPage(int page, int perPage = 5)
        {
            var data = _heroRepository.GetHeroesWithWeaponAndOwner(page, perPage);
            var viewModel = new PaginatorViewModel<HeroViewModel>();
            viewModel.Items = data
                .Heroes
                .Select(BuildHeroViewModel)
                .ToList();

            var pagesCount = data.HeroesCount % perPage == 0
                ? data.HeroesCount / perPage
                : data.HeroesCount / perPage + 1;
            var paginatorOptions = new PaginatorOptionsViewModel();
            
            paginatorOptions.CurrentPage = page;
            paginatorOptions.AvailablePages = Enumerable.Range(1, pagesCount).ToList();
            
            paginatorOptions.PerPage = perPage;

            viewModel.Options = paginatorOptions;

            return viewModel;
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

        /// <summary>
        /// Save file. Update hero avatarUrl field and return url to uploaded file
        /// </summary>
        /// <param name="heroId"></param>
        /// <param name="avatar"></param>
        /// <returns></returns>
        public string UpdateAvatar(int heroId, IFormFile avatar)
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
            return avatarUrl;
        }

        public HeroViewModel GetHero(int id)
        {
            var hero = _heroRepository.GetById(id);
            return BuildHeroViewModel(hero);
        }

        private HeroViewModel BuildHeroViewModel(Hero dbHero)
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
        }
    }
}

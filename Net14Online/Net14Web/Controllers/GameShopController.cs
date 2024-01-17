using Microsoft.AspNetCore.Mvc;
using Net14Web.DbStuff.Models;
using Net14Web.Models.GameShop;
using Net14Web.Services.GameShop;

namespace Net14Web.Controllers
{
    public class GameShopController : Controller
    {
        private Random _random = new Random();

        private readonly IGameShopRepository _repository;

        public GameShopController(IGameShopRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _repository.GetAllAsync();

            var gameViewModels = games.Select(
                game => new GameViewModel
                {
                    Id = game.Id,
                    Genre = game.Genre,
                    Name = game.Name,
                    PosterUrl = game.LogoUrl,
                    Rating = game.Raiting
                }
                ).ToList();

            return View("Index", gameViewModels);
        }

        [HttpGet]
        public IActionResult AddGame()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(AddGameViewModel gameModel)
        {
            var raiting = _random.NextDouble() * 5;
            var newGame = new Game()
            {
                Name = gameModel.Name!,
                LogoUrl = gameModel.PosterUrl,
                Genre = gameModel.Genre,
                Raiting = Math.Round(raiting, 1)
            };

            await _repository.AddAsync(newGame);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Upgrade(Game gameModel)
        {
            _repository.Update(gameModel);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _repository.DeleteById(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Profile(int id)
        {
            var game = _repository.GetById(id);

            return View("Profile", game);
        }

    }
}

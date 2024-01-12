using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.GameShop;

namespace Net14Web.Controllers
{
    public class GameShopController : Controller
    {
        public static List<GameViewModel>? GameModels = new List<GameViewModel>();
        private Random _random = new Random();

        public IActionResult Index()
        {
            return View(GameModels);
        }

        [HttpGet]
        public IActionResult AddGame()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGame(AddGameViewModel gameModel)
        {
            var raiting = _random.NextDouble() * 5;
            var newGame = new GameViewModel()
            {
                Name = gameModel.Name,
                PosterUrl = gameModel.PosterUrl,
                Genre = gameModel.Genre,
                Rating = Math.Round(raiting, 1)
            };

            GameModels!.Add(newGame);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteGame(string name)
        {
            var game = GameModels!.FirstOrDefault(x => x.Name == name);

            if (game != null) 
            {
                GameModels!.Remove(game);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateGame(string name, string posterUrl)
        {
            var game = GameModels!.FirstOrDefault(x => x.Name == name);

            game!.PosterUrl = posterUrl;

            return RedirectToAction("Index");
        }

        public IActionResult ViewGame(string name)
        {
            var game = GameModels.FirstOrDefault(x => x.Name == name);

            if (game != null) 
            {
                return View("ViewGame", game);
            }

            return RedirectToAction("Index");
        }
    }
}

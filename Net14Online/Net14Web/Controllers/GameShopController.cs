using Microsoft.AspNetCore.Mvc;
using Net14Web.DbStuff.Models.GameShop;
using Net14Web.Models.GameShop;
using Net14Web.DbStuff.Repositories.GameShop;

namespace Net14Web.Controllers
{
    public class GameShopController : Controller
    {
        private Random _random = new Random();

        private readonly GameShopRepository _gamesRepository;
        private readonly GameCommentRepository _commentsRepository;

        public GameShopController(GameShopRepository repository, GameCommentRepository commentsRepository)
        {
            _gamesRepository = repository;
            _commentsRepository = commentsRepository;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _gamesRepository.GetAllAsync();

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

            await _gamesRepository.AddAsync(newGame);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Upgrade(Game gameModel)
        {
            _gamesRepository.UpdateAsync(gameModel);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _gamesRepository.DeleteById(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int gameId, string comment)
        {
            var game = await _gamesRepository.GetById(gameId)!;

            if (game.Comments == null)
            {
                game.Comments = new List<GameComment>();
            }

            var gameComment = new GameComment()
            {
                CommentedGame = game,
                Content = comment
            };

            await _commentsRepository.AddAsync(gameComment);

            var gameViewModel = new GameViewModel()
            {
                Comments = game.Comments.Select(x => x.Content).ToList(),
                Genre = game!.Genre,
                Name = game.Name,
                PosterUrl = game.LogoUrl,
                Rating = 5d
            };

            return RedirectToAction("Profile", new { id = gameId });
        }

        [HttpGet]
        public async Task<IActionResult> Profile(int id)
        {
            var game = await _gamesRepository.GetById(id)!;

            var gameViewModel = new GameViewModel()
            {
                Id= game!.Id,
                Comments = game?.Comments?.Select(x => x.Content).ToList() ?? null,
                Genre = game!.Genre,
                Name = game.Name,
                PosterUrl = game.LogoUrl,
                Rating = 5d
            };

            return View("Profile", gameViewModel);
        }

    }
}

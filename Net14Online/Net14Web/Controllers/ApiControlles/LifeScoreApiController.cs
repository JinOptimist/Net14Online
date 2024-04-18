using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.LifeScore;
using Net14Web.Services.LifeScore;

namespace Net14Web.Controllers.ApiControlles
{
    [ApiController]
    [Route("/api/life-game/{action}")]
    public class LifeScoreApiController : Controller
    {
        private readonly SportGameService _gameService;

        public LifeScoreApiController(SportGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public List<GameViewModel> SportGames()
        {
            return _gameService.GetGames();
        }

        [HttpPost]
        public void AddSportGame(GameViewModel gameViewModel)
        {
            _gameService.CreateGame(gameViewModel);
        }
    }
}

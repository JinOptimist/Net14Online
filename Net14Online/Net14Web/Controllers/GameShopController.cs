using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net14Web.Controllers.CustomAuthAttributes;
using Net14Web.Models.GameShop;
using Net14Web.Services;
using Net14Web.Services.GameShop;

namespace Net14Web.Controllers;

public class GameShopController : Controller
{

    private readonly GamesService _gameService;
    private readonly AuthService _authService;

    public GameShopController(GamesService gameService, AuthService authService)
    {
        _gameService = gameService;
        _authService = authService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var games = await _gameService.GetItems();

        return View(games.ToList());
    }

    [HttpGet]
    public async Task<IActionResult> Profile(int id)
    {
        var game = await _gameService.GetAsync(id);
        var gameDto = _gameService.ConvertToDto(game);

        return View(gameDto);
    }

    [Authorize]
    [AdminOnly]
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var user = _authService.GetCurrentUser();
        if(user.Login!.Length >= 7)
        {
            return View("Forbidden");
        }

        await _gameService.Delete(id);

        return RedirectToAction("Index", "GameShop");
    }

    [HttpGet]
    public IActionResult AddGame()
    {
        return View();
    }

    [HttpPost]
    [AdminOnly]
    public async Task<IActionResult> AddGame(CreateGameModel gameModel)
    {
        await _gameService.CreateGame(gameModel);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> AddComment(int gameId, string comment) 
    {
        await _gameService.AddComment(gameId, comment);

        return RedirectToAction("Profile", "GameShop", new {id = gameId});
    }
}

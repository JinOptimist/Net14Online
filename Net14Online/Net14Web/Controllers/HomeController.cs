using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net14Web.DbStuff.Repositories.Movies;
using Net14Web.Models;
using Net14Web.Models.Home;
using Net14Web.Services;
using Net14Web.Services.ApiServices;
using System.Diagnostics;

namespace Net14Web.Controllers
{
    public class HomeController : Controller
    {
        private AuthService _authService;
        private UserRepository _userRepository;
        private NumberApi _numberApi;
        private DogApi _dogApi;
        private WeatherApi _weatherApi;
        private WeaterViewModelBuilder _weaterViewModelBuilder;

        public HomeController(AuthService authService,
            UserRepository userRepository,
            NumberApi numberApi,
            DogApi dogApi,
            WeatherApi weatherApi,
            WeaterViewModelBuilder weaterViewModelBuilder)
        {
            _authService = authService;
            _userRepository = userRepository;
            _numberApi = numberApi;
            _dogApi = dogApi;
            _weatherApi = weatherApi;
            _weaterViewModelBuilder = weaterViewModelBuilder;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeIndexViewModel();
            viewModel.UserName = _authService.GetCurrentUserName();
            viewModel.CurrentLocale = _authService.GetCurrentUserLocale();

            var second = DateTime.Now.Second;
            var numberFactTask = _numberApi.GetFactAboutNumber(second);
            var mathFactTask = _numberApi.GetMathFactAboutNumber(second);
            var dogDtoTask = _dogApi.GetRandomDogUrl();
            var weatherTask = _weatherApi.GetWeatherByCoordinate("52.05", "23.40");

            Task.WaitAll(numberFactTask, mathFactTask, dogDtoTask, weatherTask);

            viewModel.Number = second;
            viewModel.FactAboutNumber = numberFactTask.Result;
            viewModel.MathFactAboutNumber = mathFactTask.Result;
            viewModel.DogUrl = dogDtoTask.Result?.message ?? "";
            viewModel.WeatherViewModel = _weaterViewModelBuilder.Build(weatherTask.Result);

            return View(viewModel);
        }

        [Authorize]
        public IActionResult SwitchLocale(string locale)
        {
            var userId = _authService.GetCurrentUserId().Value;
            _userRepository.SwitchLocal(userId, locale);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Net14Web.Models;
using Net14Web.Models.Home;
using Net14Web.Services;
using System.Diagnostics;

namespace Net14Web.Controllers
{
    public class HomeController : Controller
    {
        private AuthService _authService;

        public HomeController(AuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel();
            viewModel.UserName = _authService.GetCurrentUserName();
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
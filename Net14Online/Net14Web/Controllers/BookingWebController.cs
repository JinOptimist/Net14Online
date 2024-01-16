using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Net14Web.Models.BookingWeb;

namespace Net14Web.Controllers
{
    public class BookingWebController : Controller
    {
        public static List<UserLoginViewModel> userLoginViewModel = new List<UserLoginViewModel>();

        public static List<SearchResultViewModel> searchResultViewModel = new List<SearchResultViewModel>();

        public IActionResult Help()
        {
            return View();
        }
        public IActionResult UserLogin()
        {
            return View(userLoginViewModel);
        }

        public IActionResult SearchResult()
        {
            return View(searchResultViewModel);
        }
        public IActionResult Remove(string name)
        {
            var user = userLoginViewModel.First(x => x.Name == name);
            userLoginViewModel.Remove(user);
            return RedirectToAction("UserLogin");
        }

        public IActionResult RemoveSearch(string country)
        {
            var user = searchResultViewModel.First(x => x.Country == country);
            searchResultViewModel.Remove(user);
            return RedirectToAction("SearchResult");
        }

        [HttpPost]
        public IActionResult UpdateEmail(string name, string email)
        {
            userLoginViewModel.First(x => x.Name == name).Email = email;
            return RedirectToAction("UserLogin");
        }

        [HttpPost]
        public IActionResult UpdateCity(string country, string city)
        {
            searchResultViewModel.First(x => x.Country == country).City = city;
            return RedirectToAction("SearchResult");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string name, string email, string password)
        {
            userLoginViewModel.Add(new UserLoginViewModel
            {
                Name = name,
                Email = email,
                Password = password
            });
            return RedirectToAction("UserLogin");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string country, string city, int checkin, int checkout)
        {
            searchResultViewModel.Add(new SearchResultViewModel
            {
                Country = country,
                City = city,
                CheckinDate = checkin,
                CheckoutDate = checkout
            });
            return RedirectToAction("SearchResult");
        }
    }
}
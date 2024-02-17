using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models.BookingWeb;
using Net14Web.DbStuff.Repositories.Booking;
using Net14Web.Models.BookingWeb;
using Net14Web.Models.Dnd;
using Net14Web.Services;
using System.ComponentModel.Design;
using System.Linq;

namespace Net14Web.Controllers
{
    public class BookingWebController : Controller
    {
        public static List<UserLoginViewModel> userLoginViewModel = new List<UserLoginViewModel>();

        public static List<SearchResultViewModel> searchResultViewModel = new List<SearchResultViewModel>();

        private SearchRepository _searchRepository;
        private LoginRepository _loginRepository;
        private AuthService _authService;
        
        public BookingWebController (SearchRepository searchRepository, LoginRepository loginRepository, AuthService authService)
        {
            _searchRepository = searchRepository;
            _loginRepository = loginRepository;
            _authService = authService;
        }

        public IActionResult Help()
        {
            return View();
        }
        public IActionResult UserLogin()
        {
            var logins = _loginRepository.GetLogin(10);

            var viweModel = logins.Select(login => new UserLoginViewModel
                {
                    Name = login.Name,
                    Email = login.Email,
                    Password = login.Password,
            }).ToList();

            return View(viweModel);
        }

        public IActionResult SearchResult()
        {
            var searches = _searchRepository.GetSearchLoginConnection(10);

            var viewModels = searches.Select(search => new SearchResultViewModel
            {
                Id = search.Id,
                Country = search.Country,
                City = search.City,
                CheckinDate = search.Checkin,
                CheckoutDate = search.Checkout,
                LoginEmail = search.LoginBooking.Email
            }).ToList();

            return View(viewModels);
        }

        [Authorize]
        public IActionResult Remove(int id)
        {
            _loginRepository.Delete(id);

            return RedirectToAction("UserLogin");
        }

        [Authorize]
        public IActionResult RemoveSearch(int id)
        {
            _searchRepository.Delete(id);
            return RedirectToAction("SearchResult");
        }

        [HttpPost]
        public IActionResult UpdateEmail(int loginId, string email)
        {
            _loginRepository.UpdateEmail(loginId, email);

            return RedirectToAction("UserLogin");
        }

        [HttpPost]
        public IActionResult UpdateCity(int id, string city)
        {
            _searchRepository.UpdateCity(id, city);
            return RedirectToAction("SearchResult");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel userLoginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var login = new LoginBooking
            {
                Name = userLoginViewModel.Name,
                Email = userLoginViewModel.Email,
                Password = userLoginViewModel.Password,
                Owner = _authService.GetCurrentUser()
            };
            _loginRepository.Add(login);
            return RedirectToAction("UserLogin");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel searchResultViewModel)
        {
            var login = _loginRepository.GetFirst();

            var search = new Search
            {
                Country = searchResultViewModel.Country,
                City = searchResultViewModel.City,
                Checkin = searchResultViewModel.CheckinDate,
                Checkout = searchResultViewModel.CheckoutDate,
                LoginBooking = login
            };

            _searchRepository.Add(search);

            return RedirectToAction("SearchResult");
        }

        [HttpGet]
        public IActionResult UserCountrySearch()
        {
            var userName = HttpContext.User.Claims.FirstOrDefault(x=> x.Type =="name")?.Value ?? "Guest";

            var viewModel = new UserSearchViewModel();

            viewModel.UserName = userName;
            viewModel.Logins = _loginRepository.GetAll().Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
            viewModel.Searches = _searchRepository.GetAll().Select(x => new SelectListItem(x.Country, x.Id.ToString())).ToList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UserCountrySearch(int loginId, int searchId)
        {
            return RedirectToAction("Index");
        }
    }
}
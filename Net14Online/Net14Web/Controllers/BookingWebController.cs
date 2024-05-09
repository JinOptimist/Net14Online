using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Net14Web.BusinessServices;
using Net14Web.Controllers.CustomAuthAttributes;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models.BookingWeb;
using Net14Web.DbStuff.Repositories.Booking;
using Net14Web.DbStuff.Repositories.Movies;
using Net14Web.Models.BookingWeb;
using Net14Web.Services;
using Net14Web.Services.ApiServices;
using Net14Web.Services.BookingPermissons;
using RESTCountries.NET.Models;
using RESTCountries.NET.Services;

namespace Net14Web.Controllers
{
    public class BookingWebController : Controller
    {
        public static List<UserLoginViewModel> userLoginViewModel = new List<UserLoginViewModel>();

        public static List<SearchResultViewModel> searchResultViewModel = new List<SearchResultViewModel>();

        private SearchRepository _searchRepository;
        private ClientBookingRepository _loginRepository;
        private FavouritePlaceRepository _favouritePlaceRepository;
        private WebDbContext _webDbContext;
        private UserRepository _userRepository;
        private AuthService _authService;
        private BookingPermission _bookingPermission;
        public BookingBusinessService _bookingBusinessService;
        private BookingHelperController _bookingHelperController;
        public CountryApiViewModelBuilder _countryApiViewModelBuilder;
        public CatApi _catApi;

        public BookingWebController(SearchRepository searchRepository,
            ClientBookingRepository loginRepository,
            FavouritePlaceRepository favouritePlaceRepository,
            UserRepository userRepository,
            WebDbContext webDbContext,
            AuthService authService,
            BookingPermission bookingPermission,
            BookingBusinessService bookingBusinessService,
            BookingHelperController bookingHelperController,
            CountryApiViewModelBuilder countryApiViewModelBuilder,
            CatApi catApi)
        {
            _searchRepository = searchRepository;
            _loginRepository = loginRepository;
            _favouritePlaceRepository = favouritePlaceRepository;
            _webDbContext = webDbContext;
            _userRepository = userRepository;
            _authService = authService;
            _bookingPermission = bookingPermission;
            _bookingBusinessService = bookingBusinessService;
            _bookingHelperController = bookingHelperController;
            _countryApiViewModelBuilder = countryApiViewModelBuilder;
            _catApi = catApi;
        }

        public IActionResult CarRental()
        {
            return View();
        }
        public IActionResult Flights()
        {
            return View();
        }
        public IActionResult UserChat()
        {
            var viewModel = new UserChatViewModel();
            viewModel.UserName = _authService.GetCurrentUserName();
            return View(viewModel);
        }
        public IActionResult Help()
        {
            return View();
        }
        public IActionResult UserLogin()
        {
            var logins = _loginRepository.GetLoginWithOwner(100);

            var viewModel = logins.Select(login => new UserLoginViewModel
            {
                Id = login.Id,
                Name = login.Name,
                Email = login.Email,
                Password = login.Password,
                Owner = login.Owner?.Login ?? "Unknown",
                CanDelete = login.Owner is null || login.Owner.Id == _authService.GetCurrentUserId()
            })
                .ToList();

            return View(viewModel);
        }

        public IActionResult SearchResult()
        {
            var userName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "name")?.Value ?? "Guest";
            var searches = _searchRepository.GetSearchLoginConnection(100);

            var viewModels = searches.Select(search => new SearchResultViewModel
            {
                Id = search.Id,
                Country = search.Country,
                City = search.City,
                CheckinDate = search.Checkin,
                CheckoutDate = search.Checkout,
                ClientEmail = search.ClientBooking.Email,
                Owner = search.Owner?.Login ?? "Unknown",
                CanDelete = _bookingPermission.CanDelete(search)
            }).ToList();

            return View(new SearchResultPageViewModel
            {
                SearchResults = viewModels,
                UserName = userName
            });
        }

        [AdminOnly]
        public IActionResult Remove(int id)
        {
            _loginRepository.Delete(id);

            return RedirectToAction("UserLogin");
        }

        [Authorize]
        public IActionResult RemoveSearch(int id)
        {
            var search = _searchRepository.GetByIdWithOwner(id);
            if (!_bookingPermission.CanDelete(search))
            {
                throw new Exception("You have no access");
            }
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

            var login = new ClientBooking
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
        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexViewModel();
            var random = new Random();
            var allCountries = RestCountriesService.GetAllCountries().ToList();
            var catDtoTask = _catApi.GetRandomImageUrl();

            var randomCountry = allCountries[random.Next(allCountries.Count)];
            var countryViewModel = _countryApiViewModelBuilder.Build(randomCountry);
            viewModel.CountryApiViewModel = countryViewModel;
            viewModel.catUrl = catDtoTask.Result.url;
            return View(viewModel);

        }

        [HttpPost]
        public IActionResult Index(IndexViewModel searchResultViewModel)
        {
            var login = _loginRepository.GetFirst();

            _bookingBusinessService.AddSearch(searchResultViewModel);

            return RedirectToAction("SearchResult");
        }

        [HttpGet]
        public IActionResult UserCountrySearch()
        {
            var userName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "name")?.Value ?? "Guest";

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

        [Authorize]
        [HttpGet]
        public IActionResult FavouritePlaces()
        {
            var user = _authService.GetCurrentUser();
            var viewModel = new FavouritePlacesViewModel();

            viewModel.AllPlaces = _favouritePlaceRepository
                .GetAll()
                .Select(x => new SelectListItem(x.City, x.Id.ToString()))
                .ToList();
            viewModel.UserName = user?.Login ?? "Guest";
            viewModel.Id = user.Id;

            viewModel.UserFavouritePlaces = _favouritePlaceRepository.GetFavouritePlacesByUserId(user.Id);

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult FavouritePlaces(int userId, int favPlaceId)
        {
            var user = _authService.GetCurrentUser();
            _userRepository.AddFavouritePlace(userId, favPlaceId);
           

            return RedirectToAction(nameof(FavouritePlaces));
        }
    }
}
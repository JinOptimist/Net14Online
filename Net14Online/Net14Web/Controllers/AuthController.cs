using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Net14Web.DbStuff.Repositories.Movies;
using Net14Web.Models.Auth;
using System.Security.Claims;
using Net14Web.DbStuff.Repositories.RealEstate;

namespace Net14Web.Controllers
{
    public class AuthController : Controller
    {
        private UserRepository _userRepository;
        private ApartmentOwnerRepository _apartmentOwnerRepository;

        public const string AUTH_KEY = "Smile";
        public const string REAL_ESTATE_AUTH_KEY = "RealEstateKey";

        public AuthController(UserRepository userRepository,ApartmentOwnerRepository apartmentOwnerRepository)
        {
            _userRepository = userRepository;
            _apartmentOwnerRepository = apartmentOwnerRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AuthViewModel authViewModel)
        {
            var user = _userRepository.GetUserByLoginAndPassword(authViewModel.UserName, authViewModel.Password);
            if (user == null)
            {
                ModelState.AddModelError(nameof(AuthViewModel.UserName), "Wrong name or passwrod");
                return View(authViewModel);
            }

            var claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim("name", user.Login.ToString()),
                new Claim("email", user.Email ?? ""),
            };

            var identity = new ClaimsIdentity(claims, AUTH_KEY);
            var principal = new ClaimsPrincipal(identity);
            HttpContext
                .SignInAsync(AUTH_KEY, principal)
                .Wait();

            return RedirectToAction("Index", "Home");
        }
    
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult RealEstateLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RealEstateLogin(AuthViewModel authViewModel)
        {
            var apartmentOwner = _apartmentOwnerRepository.GetUserByLoginAndPassword(authViewModel.UserName, authViewModel.Password);
            
            if (apartmentOwner == null)
            {
                ModelState.AddModelError(nameof(authViewModel.UserName), "Wrong name or passwrod");
                return View(authViewModel);
            }
            var claims = new List<Claim>
            {
                new Claim("id",apartmentOwner.Id.ToString()),
                new Claim("name",apartmentOwner.Login),
                new Claim("email",apartmentOwner.Email)
            };

            var identity = new ClaimsIdentity(claims, REAL_ESTATE_AUTH_KEY);
            var principal = new ClaimsPrincipal(identity);
            HttpContext
                .SignInAsync(REAL_ESTATE_AUTH_KEY, principal)
                .Wait();

            return RedirectToAction("Main","RealEstate");
        }
        
        public IActionResult RealEstateLogaut()
        {
            HttpContext
                .SignOutAsync()
                .Wait();
            return RedirectToAction("Index","Home");
        }
    }
}

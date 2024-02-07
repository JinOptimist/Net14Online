using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Net14Web.DbStuff.ManagmentCompany.Models;
using Net14Web.DbStuff.ManagmentCompany.Models.Enums;
using Net14Web.DbStuff.Repositories;
using Net14Web.DbStuff.Repositories.ManagmentCompany;
using Net14Web.DbStuff.Repositories.Movies;
using Net14Web.Models.Auth;
using Net14Web.Models.ManagmentCompany;
using System.Security.Claims;

namespace Net14Web.Controllers
{
    public class AuthController : Controller
    {
        private UserRepository _userRepository;

        private McUserRepository _mcUserRepository;

        public const string AUTH_KEY = "Smile";

        public AuthController(UserRepository userRepository, McUserRepository mcUserRepository)
        {
            _userRepository = userRepository;
            _mcUserRepository = mcUserRepository;
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

        public IActionResult McLogin()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult McLogin(LoginViewModel loginViewModel)
        {
            var user = _mcUserRepository.GetLogUser(loginViewModel.Email, loginViewModel.Password);
            if (user == null)
            {
                ModelState.AddModelError(nameof(LoginViewModel.Email), "Wrong name or password");
                return View(loginViewModel);
            }

            var claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim("permissionId", user.MemberPermission?.Id.ToString() ?? ""),
                new Claim("email", user.Email ?? ""),
            };

            var identity = new ClaimsIdentity(claims, AUTH_KEY);
            var principal = new ClaimsPrincipal(identity);
            HttpContext
                .SignInAsync(AUTH_KEY, principal)
                .Wait();

            if (user.MemberPermission?.Id == (int)MemberPermissionEnum.User)
            {
                return RedirectToAction("Profile", "ManagmentCompany");
            }
            else
            {
                return RedirectToAction("AdminPanel", "ManagmentCompany");
            }
        }

        public IActionResult McLogout()
        {
            HttpContext.SignOutAsync().Wait();
            return RedirectToAction("Index", "ManagmentCompany");
        }
    }
}

using ManagementCompany.DbStuff.Models.Enums;
using ManagementCompany.DbStuff.Repositories;
using ManagementCompany.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ManagementCompany.Controllers
{
    public class AuthController : Controller
    {
        private UserRepository _userRepository;

        public const string AUTH_KEY_MC = "McCompany";

        public AuthController(UserRepository mcUserRepository)
        {
            _userRepository = mcUserRepository;
        }

        public IActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var user = _userRepository.GetLogUser(loginViewModel.Email, loginViewModel.Password);
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

            var identity = new ClaimsIdentity(claims, AUTH_KEY_MC);
            var principal = new ClaimsPrincipal(identity);
            HttpContext
                .SignInAsync(AUTH_KEY_MC, principal)
                .Wait();

            if (user.MemberPermission?.Id == (int)MemberPermissionEnum.User)
            {
                return RedirectToAction("Profile", "ManagementCompany");
            }
            else
            {
                return RedirectToAction("AdminPanel", "ManagementCompany");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync().Wait();
            return RedirectToAction("Index", "ManagementCompany");
        }
    }
}

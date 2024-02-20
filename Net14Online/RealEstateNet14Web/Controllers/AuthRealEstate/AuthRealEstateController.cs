using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstateNet14Web.DbStuff.Repositories;
using RealEstateNet14Web.Models.Auth;
using RealEstateNet14Web.Services.Auth;

namespace RealEstateNet14Web.Controllers.Auth;

public class AuthRealEstateController : Controller
{
    public  const string AUTH_KEY_REAL_ESTATE = "RealEstateKey";
    private ApartmentOwnerRepository _apartmentOwnerRepository;

    public AuthRealEstateController(ApartmentOwnerRepository apartmentOwnerRepository)
    {
        _apartmentOwnerRepository = apartmentOwnerRepository;
    }
    [HttpGet]
    public IActionResult RealEstateLogin()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RealEstateLogin(AuthViewModel authViewModel)
    {
        var apartmentOwner =
            _apartmentOwnerRepository.GetUserByLoginAndPassword(authViewModel.UserName, authViewModel.Password);

        if (apartmentOwner == null)
        {
            ModelState.AddModelError(nameof(AuthViewModel.UserName), "Wrong name or passwrod");
            return View(authViewModel);
        }

        var claims = new List<Claim>
        {
            new("id", apartmentOwner.Id.ToString()),
            new("name", apartmentOwner.Login),
            new("email", apartmentOwner.Email)
        };
        
        var identity = new ClaimsIdentity(claims, AUTH_KEY_REAL_ESTATE);
        var principal = new ClaimsPrincipal(identity);
        HttpContext
            .SignInAsync(AUTH_KEY_REAL_ESTATE, principal)
            .Wait();
        
        return RedirectToAction("DataBase","RealEstate");
    }

    public IActionResult RealEstateLogout()
    {
        HttpContext.SignOutAsync().Wait();
        return RedirectToAction("Index", "Home");
    }
}
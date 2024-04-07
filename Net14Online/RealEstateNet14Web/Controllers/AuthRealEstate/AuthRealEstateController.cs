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
    private RealEstateOwnerRepository _realEstateOwnerRepository;

    public AuthRealEstateController(RealEstateOwnerRepository realEstateOwnerRepository)
    {
        _realEstateOwnerRepository = realEstateOwnerRepository;
    }
    [HttpGet]
    public IActionResult RealEstateLogin()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RealEstateLogin(AuthViewModel authViewModel)
    {
        var realEstateOwner =
            _realEstateOwnerRepository.GetUserByLoginAndPassword(authViewModel.UserName, authViewModel.Password);

        if (realEstateOwner == null)
        {
            ModelState.AddModelError(nameof(AuthViewModel.UserName), "Wrong name or passwrod");
            return View(authViewModel);
        }

        var claims = new List<Claim>
        {
            new("id", realEstateOwner.Id.ToString()),
            new("name", realEstateOwner.Login),
            new("email", realEstateOwner.Email)
        };
        
        var identity = new ClaimsIdentity(claims, AUTH_KEY_REAL_ESTATE);
        var principal = new ClaimsPrincipal(identity);
        HttpContext
            .SignInAsync(AUTH_KEY_REAL_ESTATE, principal)
            .Wait();
        
        return RedirectToAction("Main","RealEstate");
    }

    public IActionResult RealEstateLogout()
    {
        HttpContext.SignOutAsync().Wait();
        return RedirectToAction("Main", "RealEstate");
    }
}
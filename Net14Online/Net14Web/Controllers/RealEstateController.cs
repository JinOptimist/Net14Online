using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net14Web.DbStuff.RealEstate.Models;
using Net14Web.DbStuff.Repositories.RealEstate;
using Net14Web.Models.Auth;
using Net14Web.Models.RealEstate;
using Net14Web.Services.RealEstate;

namespace Net14Web.Controllers;

public class RealEstateController : Controller
{
    public readonly UserBuilder _userBuilder;
    private ApartmentOwnerRepository _apartmentOwnerRepository;
    private ApartmentRepository _apartmentRepository;
    private RealEstateAuthService _realEstateAuthService;
        
    public static List<ApartmentOwnerViewModel> userViewModels = new();

    public RealEstateController(UserBuilder userBuilder,
        ApartmentOwnerRepository apartmentOwnerRepository,
        RealEstateAuthService realEstateAuthService,
        ApartmentRepository apartmentRepository)
    {
        _userBuilder = userBuilder;
        _apartmentOwnerRepository = apartmentOwnerRepository;
        _realEstateAuthService = realEstateAuthService;
        _apartmentRepository = apartmentRepository;
    }
    public IActionResult Main()
    {
        return View(userViewModels);
    }
    
    public IActionResult DataBase()
    {
        var dbApartmentOwners = _apartmentOwnerRepository.GetApartamentOwners(10);

        var viewModels = dbApartmentOwners
            .Select(dbApartmentOwner => new ApartmentOwnerViewModel()
            {
                Age = dbApartmentOwner.Age,
                Name = dbApartmentOwner.Name,
                KindOfActivity = dbApartmentOwner.KindOfActivity,
            })
            .ToList();

        return View(dbApartmentOwners);
    }
    
    [HttpGet]
    public IActionResult AddUser()
    {
        return View();
    }

    [HttpGet]
    [Authorize]
    public IActionResult Update(int id)
    {
        var user = _apartmentOwnerRepository.GetById(id);
        return View(user);
    }
    
    [HttpPost]
    [Authorize]
    public IActionResult Update(int id,string name,int age,string kindOfActivity)
    {
        var user = _apartmentOwnerRepository.GetById(id);
        _apartmentOwnerRepository.Update(user,name, age, kindOfActivity);
        return RedirectToAction("DataBase");
    }

    [Authorize]
    public IActionResult Delete(int id)
    {
        _apartmentOwnerRepository.Delete(id);
        return RedirectToAction("DataBase");
    }
    
    
    [HttpPost]
    public IActionResult AddUser(AddUserViewModel user)
    {
        var newUser = _userBuilder.BuilderUser(user);
        _apartmentOwnerRepository.Add(newUser);
        
        return RedirectToAction("DataBase");
    }

    [HttpGet]
    [Authorize]
    public IActionResult AddApartament()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    public IActionResult AddApartament(Apartament apartament)
    {
        var newApartament = new Apartament
        {
            Size = apartament.Size,
            City = apartament.City,
            Street = apartament.Street,
            NumberApartament = apartament.NumberApartament,
            ApartmentOwner = _realEstateAuthService.GetCurrentUserApartmentOwner()
        };
        
        _apartmentRepository.Add(newApartament);
        
        return RedirectToAction("Main");
    }

    public IActionResult CheckAllApartaments()
    {
        var dbAapartaments = _apartmentRepository.GetApartamentsAndApartmentOwners(10);
        
        var viewModels = dbAapartaments
            .Select(dbApartament => new ApartamentViewModel
            {
                Size = dbApartament.Size,
                City = dbApartament.City,
                Street = dbApartament.Street,
                NumberApartament = dbApartament.NumberApartament,
                OwnerName = dbApartament.ApartmentOwner?.Login ?? "Неизвестен"
            })
            .ToList();
        return View(viewModels);
    }
}
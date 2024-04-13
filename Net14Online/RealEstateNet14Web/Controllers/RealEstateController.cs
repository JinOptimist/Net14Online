using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateNet14Web.BuisnessService;
using RealEstateNet14Web.DbStuff.Models;
using RealEstateNet14Web.DbStuff.Repositories;
using RealEstateNet14Web.Models;
using RealEstateNet14Web.Models.ChatModels;
using RealEstateNet14Web.Services;
using RealEstateNet14Web.Services.Auth;

namespace RealEstateNet14Web.Controllers;

public class RealEstateController : Controller
{
  
    private RealEstateOwnerRepository _realEstateOwnerRepository;
    private RealEstateAuthService _realEstateAuthService;
    private RealEstateRepository _realEstateRepository;
    private RealEstateOwnerBuisnessService _realEstateOwnerBuisnessService;
    private GetRealEstate _getRealEstate;

    public RealEstateController(RealEstateOwnerRepository realEstateOwnerRepository,
        RealEstateAuthService realEstateAuthService,
        RealEstateRepository realEstateRepository,
        RealEstateOwnerBuisnessService realEstateOwnerBuisnessService,
        GetRealEstate getRealEstates)
    {
        _realEstateOwnerRepository = realEstateOwnerRepository;
        _realEstateAuthService = realEstateAuthService;
        _realEstateRepository = realEstateRepository;
        _realEstateOwnerBuisnessService = realEstateOwnerBuisnessService;
        _getRealEstate = getRealEstates;
    }

    public IActionResult Main()
    {
        var viewModel = new ChatViewModel();
        viewModel.UserName = _realEstateAuthService.GetCurrentUserName();
        return View(viewModel);
    }
   
    [HttpGet]
    [Authorize]
    public IActionResult DataBase()
    {
        var viewModels = _realEstateOwnerBuisnessService.GetRealEstateOwners();

        return View(viewModels);
    }
    
    [ HttpGet]
    public IActionResult AddUser()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpGet]
    [Authorize]
    public IActionResult Update(int id)
    {
        var user = _realEstateOwnerRepository.GetById(id);
        return View(user);
    }
    
    [HttpPost]
    [Authorize]
    public IActionResult Update(int id,string name,int age,string kindOfActivity)
    {
        var user = _realEstateOwnerRepository.GetById(id);
        _realEstateOwnerRepository.Update(user,name, age, kindOfActivity);
        return RedirectToAction("DataBase");
    }

    [HttpGet]
    [Authorize]
    public IActionResult Delete(int id)
    {
         _realEstateOwnerRepository.Delete(id);
        return RedirectToAction("DataBase");
    }
    
    [HttpPost]
    public IActionResult AddUser(AddUserViewModel addUser)
    {
        _realEstateOwnerBuisnessService.AddRealEstateOwner(addUser);
        
        return RedirectToAction("DataBase");
    }

    [HttpGet]
    public IActionResult AddRealEstate()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddRealEstate(RealEstateViewModel realEstateViewModel)
    {
        var realEstate = new RealEstate
        {
            City = realEstateViewModel.City,
            Street = realEstateViewModel.Street,
            Size = realEstateViewModel.Size,
            Status = realEstateViewModel.Status,
            RealEstateOwner = _realEstateAuthService.GetCurrentUser()
        };
        _realEstateRepository.Add(realEstate);

        return RedirectToAction("Main");
    }

    [HttpGet]
    public IActionResult CheckAllRealEstate()
    {
        var realEstates = _realEstateRepository.GetRealEstatesAndRealEstateOwner(10);

        var viewModel = realEstates.
            Select(realEstate => new RealEstateViewModel
        {
            City = realEstate.City,
            Street = realEstate.Street,
            Size = realEstate.Size,
            Status = realEstate.Status,
            OwnerName = realEstate.RealEstateOwner?.Login ?? "---"
        }).ToList();

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult CheckRealEstateWithStatus(string status)
    {
        var realEstates = _realEstateRepository.GetRealEstatesAndRealEstateOwner(10);

        var viewModel = _getRealEstate.GetRealEstatesWithStatus(status,realEstates);

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult GetRealEstateByType(string type)
    {
        var realEstates = _realEstateRepository.GetRealEstatesAndRealEstateOwner(10);

        var viewModel = _getRealEstate.GetRealEstatesByType(realEstates, type);

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult SearchRealEstate(string type, int countRoom, int price, string city)
    {
        var realEstates = _realEstateRepository.GetRealEstatesAndRealEstateOwner(10);

        var viewModel = _getRealEstate.GetRealEstatesByData(realEstates,type, countRoom, price, city);

        return View(viewModel);
    }
    
    
}
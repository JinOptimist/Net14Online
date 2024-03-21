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
   //  public readonly UserBuilder _userBuilder;
    public readonly DeleteUser _deleteUser;
    public readonly UpdateUser _updateUser;
    private ApartmentOwnerRepository _apartmentOwnerRepository;
    private RealEstateAuthService _realEstateAuthService;
    private ApartamentRepository _apartamentRepository;
    private ApartmentOwnerBuisnessService _apartmentOwnerBuisnessService;
    

    public RealEstateController(DeleteUser deleteUser,
        UpdateUser updateUser,
        ApartmentOwnerRepository apartmentOwnerRepository,
        RealEstateAuthService realEstateAuthService,
        ApartamentRepository apartamentRepository,
        ApartmentOwnerBuisnessService apartmentOwnerBuisnessService)
    {
       // _userBuilder = userBuilder;
        _deleteUser = deleteUser;
        _updateUser = updateUser;
        _apartmentOwnerRepository = apartmentOwnerRepository;
        _realEstateAuthService = realEstateAuthService;
        _apartamentRepository = apartamentRepository;
        _apartmentOwnerBuisnessService = apartmentOwnerBuisnessService;
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
        var viewModels = _apartmentOwnerBuisnessService.GetApartamentOwners();

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

    [HttpGet]
    [Authorize]
    public IActionResult Delete(int id)
    {
         _apartmentOwnerRepository.Delete(id);
        return RedirectToAction("DataBase");
    }
    
    [HttpPost]
    public IActionResult AddUser(AddUserViewModel addUser)
    {
        _apartmentOwnerBuisnessService.AddApartmentOwner(addUser);
        
        return RedirectToAction("DataBase");
    }

    [HttpGet]
    public IActionResult AddApartament()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddApartament(ApartamentViewModel apartamentViewModel)
    {
        var newApartament = new Apartament
        {
            City = apartamentViewModel.City,
            Street = apartamentViewModel.Street,
            NumberApartament = apartamentViewModel.NumberApartament,
            Size = apartamentViewModel.Size,
            ApartmentOwner = _realEstateAuthService.GetCurrentUser()
        };
        _apartamentRepository.Add(newApartament);

        return RedirectToAction("Main");
    }

    [HttpGet]
    public IActionResult CheckAllApartaments()
    {
        var dbApartaments = _apartamentRepository.GetApartamentsAndApartmentOwner(10);

        var viewModel = dbApartaments.
            Select(dbApartament => new ApartamentViewModel
        {
            City = dbApartament.City,
            Street = dbApartament.Street,
            NumberApartament = dbApartament.NumberApartament,
            Size = dbApartament.Size,
            OwnerName = dbApartament.ApartmentOwner?.Login ?? "---"
        }).ToList();

        return View(viewModel);
    }
    
}
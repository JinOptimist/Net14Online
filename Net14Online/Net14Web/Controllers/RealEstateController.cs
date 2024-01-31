using Microsoft.AspNetCore.Mvc;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.RealEstate;
using Net14Web.DbStuff.RealEstate.Models;
using Net14Web.DbStuff.Repositories.RealEstate;
using Net14Web.Models.RealEstate;
using Net14Web.Services.RealEstate;

namespace Net14Web.Controllers;

public class RealEstateController : Controller
{
    public readonly UserBuilder _userBuilder;
    public readonly DeleteUser _deleteUser;
    public readonly UpdateUser _updateUser;
    private ApartmentOwnerRepository _apartmentOwnerRepository;
        
    public static List<UserViewModel> userViewModels = new();

    public RealEstateController(UserBuilder userBuilder,DeleteUser deleteUser,UpdateUser updateUser, ApartmentOwnerRepository apartmentOwnerRepository)
    {
        _userBuilder = userBuilder;
        _deleteUser = deleteUser;
        _updateUser = updateUser;
        _apartmentOwnerRepository = apartmentOwnerRepository;
    }
    public IActionResult Main()
    {
        return View(userViewModels);
    }
    
    public IActionResult DataBase()
    {
        var dbApartmentOwners = _apartmentOwnerRepository.GetApartamentOwners(10);

        var viewModels = dbApartmentOwners
            .Select(dbUser => new UserViewModel()
            {
                Age = dbUser.Age,
                Name = dbUser.Name,
                KindOfActivity = dbUser.KindOfActivity,
            })
            .ToList();

        return View(dbApartmentOwners);
    }
    
    [HttpGet]
    public IActionResult AddUser()
    {
        return View();
    }
    
    public IActionResult Login()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var user = _apartmentOwnerRepository.GetById(id);
        return View(user);
    }
    
    [HttpPost]
    public IActionResult Update(int id,string name,int age,string kindOfActivity)
    {
        var user = _apartmentOwnerRepository.GetById(id);
        _apartmentOwnerRepository.Update(user,name, age, kindOfActivity);
        return RedirectToAction("DataBase");
    }

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
}
using Microsoft.AspNetCore.Mvc;
using RealEstateNet14Web.DbStuff.Models;
using RealEstateNet14Web.DbStuff.Repositories;
using RealEstateNet14Web.Models;
using RealEstateNet14Web.Services;

namespace RealEstateNet14Web.Controllers;

public class RealEstateController : Controller
{
   //  public readonly UserBuilder _userBuilder;
    public readonly DeleteUser _deleteUser;
    public readonly UpdateUser _updateUser;
    private ApartmentOwnerRepository _apartmentOwnerRepository;
        
    public static List<UserViewModel> userViewModels = new();

    public RealEstateController(DeleteUser deleteUser,UpdateUser updateUser, ApartmentOwnerRepository apartmentOwnerRepository)
    {
       // _userBuilder = userBuilder;
        _deleteUser = deleteUser;
        _updateUser = updateUser;
        _apartmentOwnerRepository = apartmentOwnerRepository;
    }
   
    public IActionResult Main()
    {
        return View(userViewModels);
    }
   
    [HttpGet]
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

    [HttpGet]
    public IActionResult Delete(int id)
    {
        _apartmentOwnerRepository.Delete(id);
        return RedirectToAction("DataBase");
    }
    
    
    [HttpPost]
    public IActionResult AddUser(AddUserViewModel addUser)
    {
       // var newUser = _userBuilder.BuilderUser(user);
       var newUser = new ApartmentOwner()
       {
           Name = addUser.Name,
           Age = addUser.Age,
           KindOfActivity = addUser.KindOfActivity,
       };
      // _apartmentOwnerRepository.Add(newUser);
        _apartmentOwnerRepository.Add(newUser);
        
        return RedirectToAction("DataBase");
    }
}
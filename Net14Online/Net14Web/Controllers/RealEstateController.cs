using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.RealEstate;
using Net14Web.Services.RealEstate;

namespace Net14Web.Controllers;

public class RealEstateController : Controller
{
    public readonly UserBuilder _userBuilder;
    public readonly DeleteUser _deleteUser;
    public readonly UpdateUser _updateUser;
        
    public static List<UserViewModel> userViewModels = new();

    public RealEstateController(UserBuilder userBuilder,DeleteUser deleteUser,UpdateUser updateUser)
    {
        _userBuilder = userBuilder;
        _deleteUser = deleteUser;
        _updateUser = updateUser;
    }
    public IActionResult Main()
    {
        return View(userViewModels);
    }
    
    public IActionResult DataBase()
    {
        return View(userViewModels);
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
    public IActionResult Update(string id)
    {
        var user = userViewModels.First(x => x.Id == id);
        return View(user);
    }
    
    [HttpPost]
    public IActionResult Update(string id,string kindOfActivity,int age,string name)
    {
       
       _updateUser.Update(userViewModels, id, name, age,kindOfActivity);
        return RedirectToAction("DataBase");
    }

    public IActionResult Delete(string id)
    {
        var user = _deleteUser.UserDelete(userViewModels, id);
        userViewModels.Remove(user);
        
        return RedirectToAction("DataBase");
    }
    
    [HttpPost]
    public IActionResult AddUser(AddUserViewModel userViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(userViewModel);
        }
        
        var newUser = _userBuilder.BuilderUser(userViewModel);
        userViewModels.Add(newUser);

        return RedirectToAction("DataBase");
    }
}
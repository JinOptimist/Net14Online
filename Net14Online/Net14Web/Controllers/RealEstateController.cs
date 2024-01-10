using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.RealEstate;

namespace Net14Web.Controllers;

public class RealEstateController : Controller
{
    public static List<UserViewModel> userViewModels = new();
    
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

    [HttpPost]
    public IActionResult AddUser(AddUserViewModel userViewModel)
    {
        var newUser = new UserViewModel
        {
            Name = userViewModel.Name,
            Age = userViewModel.Age,
            KindOfActivity = userViewModel.KindOfActivity
        };
        
        userViewModels.Add(newUser);

        return RedirectToAction("DataBase");
    }

    
    
}
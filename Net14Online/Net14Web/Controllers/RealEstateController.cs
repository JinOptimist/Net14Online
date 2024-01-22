using Microsoft.AspNetCore.Mvc;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models;
using Net14Web.Models.RealEstate;
using Net14Web.Services.RealEstate;

namespace Net14Web.Controllers;

public class RealEstateController : Controller
{
    public readonly UserBuilder _userBuilder;
    public readonly DeleteUser _deleteUser;
    public readonly UpdateUser _updateUser;
    private WebDbContextRealEstate _webDbContextRealEstate;
        
    public static List<UserViewModel> userViewModels = new();

    public RealEstateController(UserBuilder userBuilder,DeleteUser deleteUser,UpdateUser updateUser,WebDbContextRealEstate webDbContextRealEstate)
    {
        _userBuilder = userBuilder;
        _deleteUser = deleteUser;
        _updateUser = updateUser;
        _webDbContextRealEstate = webDbContextRealEstate;
    }
    public IActionResult Main()
    {
        return View(userViewModels);
    }
    
    public IActionResult DataBase()
    {
        var dbUsers = _webDbContextRealEstate.Users.Take(10).ToList();

        var viewModels = dbUsers
            .Select(dbUser => new UserViewModel()
            {
                Age = dbUser.Age,
                Name = dbUser.Name,
                KindOfActivity = dbUser.KindOfActivity,
            })
            .ToList();

        return View(viewModels);
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
        var user = _webDbContextRealEstate.Users.First(x => x.Id == id);
        return View(user);
    }
    
    [HttpPost]
    public IActionResult Update(int id,string kindOfActivity,int age,string name)
    {
        _updateUser.Update(_webDbContextRealEstate.Users, id, name, age,kindOfActivity);
        return RedirectToAction("DataBase");
    }

    public IActionResult Delete(int id)
    {
        var user = _deleteUser.UserDelete(_webDbContextRealEstate.Users,id);
        _webDbContextRealEstate.Users.Remove(user);
        
        return RedirectToAction("DataBase");
    }
    
    
    [HttpPost]
    public IActionResult AddUser(User user)
    {
        var newUser = _userBuilder.BuilderUser(user);

        _webDbContextRealEstate.Users.Add(newUser);

        _webDbContextRealEstate.SaveChanges();

        return RedirectToAction("DataBase");
    }
}
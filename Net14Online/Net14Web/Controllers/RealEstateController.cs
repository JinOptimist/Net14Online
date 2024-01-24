using Microsoft.AspNetCore.Mvc;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.RealEstate;
using Net14Web.DbStuff.RealEstate.Models;
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
        var dbUsers = _webDbContextRealEstate.ApartmentOwners.Take(10).ToList();

        var viewModels = dbUsers
            .Select(dbUser => new UserViewModel()
            {
                Age = dbUser.Age,
                Name = dbUser.Name,
                KindOfActivity = dbUser.KindOfActivity,
            })
            .ToList();

        return View(dbUsers);
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
        var user = _webDbContextRealEstate.ApartmentOwners.ToList().FirstOrDefault(x => x.Id == id);
        return View(user);
    }
    
    [HttpPost]
    public IActionResult Update(int id,string name,int age,string kindOfActivity)
    {
        _updateUser.Update(_webDbContextRealEstate.ApartmentOwners.ToList(),id,name,age,kindOfActivity);
        _webDbContextRealEstate.SaveChanges();
        return RedirectToAction("DataBase");
    }

    public IActionResult Delete(int id)
    {
        var user = _deleteUser.UserDelete(_webDbContextRealEstate.ApartmentOwners.ToList(),id);
        _webDbContextRealEstate.ApartmentOwners.Remove(user);
       _webDbContextRealEstate.SaveChanges();
        
        return RedirectToAction("DataBase");
    }
    
    
    [HttpPost]
    public IActionResult AddUser(AddUserViewModel user)
    {
        var newUser = _userBuilder.BuilderUser(user);
        
        _webDbContextRealEstate.ApartmentOwners.Add(newUser);
     
       _webDbContextRealEstate.SaveChanges();
        
        return RedirectToAction("DataBase");
    }
}
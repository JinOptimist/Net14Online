using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    private WebDbRealEstateContext _webRealEstateDbContext;

    public static List<UserViewModel> userViewModels = new();

    public RealEstateController(UserBuilder userBuilder, DeleteUser deleteUser, UpdateUser updateUser,
        WebDbRealEstateContext webDbContextRealEstate)
    {
        _userBuilder = userBuilder;
        _deleteUser = deleteUser;
        _updateUser = updateUser;
        _webRealEstateDbContext = webDbContextRealEstate;
    }

    public IActionResult Main()
    {
        return View(userViewModels);
    }

    public IActionResult DataBase()
    {
        var dbUsers = _webRealEstateDbContext.ApartmentOwners.Take(10).ToList();

        var viewModels = dbUsers
            .Select(dbUser => new UserViewModel()
            {
                Age = dbUser.Age,
                Name = dbUser.Name,
                KindOfActivity = dbUser.KindOfActivity,
                CountApartaments = dbUser.Apartaments.Count
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
        var user = _webRealEstateDbContext.ApartmentOwners.ToList().FirstOrDefault(x => x.Id == id);
        return View(user);
    }

    [HttpPost]
    public IActionResult Update(int id, string name, int age, string kindOfActivity)
    {
        _updateUser.Update(_webRealEstateDbContext.ApartmentOwners.ToList(), id, name, age, kindOfActivity);
        _webRealEstateDbContext.SaveChanges();
        return RedirectToAction("DataBase");
    }

    public IActionResult Delete(int id)
    {
        var user = _deleteUser.UserDelete(_webRealEstateDbContext.ApartmentOwners.ToList(), id);
        _webRealEstateDbContext.ApartmentOwners.Remove(user);
        _webRealEstateDbContext.SaveChanges();

        return RedirectToAction("DataBase");
    }
    
    [HttpPost]
    public IActionResult AddUser(AddUserViewModel user)
    {
        var newUser = _userBuilder.BuilderUser(user);

        _webRealEstateDbContext.ApartmentOwners.Add(newUser);

        _webRealEstateDbContext.SaveChanges();

        return RedirectToAction("DataBase");
    }

    [HttpGet]
    public IActionResult ChooseApartaments()
    {
        var viewModel = new ApartamentsViewModel();

        viewModel.ApartamentOwners =
            _webRealEstateDbContext.ApartmentOwners
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

        viewModel.Apartaments =
            _webRealEstateDbContext.Apartaments
                .Select(x => new SelectListItem(x.Size, x.Id.ToString()))
                .ToList();

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult ChooseApartaments(int apartmentOwnerId, int apartamanetId)
    {
        var apartmentOwner = _webRealEstateDbContext.ApartmentOwners.First(x => x.Id == apartmentOwnerId);
        var apartament = _webRealEstateDbContext.Apartaments.First(x => x.Id == apartamanetId);

        var newApartament = new Apartament
        {
            Size = apartament.Size,
            ApartmentOwner = apartmentOwner
        };

        apartmentOwner.Apartaments.Add(newApartament);
        _webRealEstateDbContext.SaveChanges();

        return RedirectToAction("DataBase");
    }
    
}    
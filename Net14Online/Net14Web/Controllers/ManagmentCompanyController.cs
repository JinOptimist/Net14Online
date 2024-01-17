using Microsoft.AspNetCore.Mvc;
using Net14Web.DbStuff;
using Net14Web.DbStuff.ManagmentCompany.Models;
using Net14Web.Models.ManagmentCompany;


namespace Net14Web.Controllers
{
    public class ManagmentCompanyController : Controller
    {
        private ManagmentCompanyDbContext _managmentCompanyDbContext;

        public ManagmentCompanyController(ManagmentCompanyDbContext managmentCompanyDbContext)
        {
            _managmentCompanyDbContext = managmentCompanyDbContext;
        }

        public IActionResult Index()
        {
            var dbUsers = _managmentCompanyDbContext.Users.ToList();

            var viewModels = dbUsers
                .Select(dbUser => new UserViewModel
                {
                    NickName = dbUser.NickName,
                    PermissionLevel = dbUser.UserPermission,
                })
                .ToList();

            return View(viewModels);
            
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult LogError()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationViewModel userViewModel)
        {
            var user = new User
            {
                Id = userViewModel.Id,
                LastName = userViewModel.Name,
                NickName = userViewModel.NickName,
                Password = userViewModel.Password,
                UserPermission = "Пользователь",
            };

            _managmentCompanyDbContext.Add(user);
            _managmentCompanyDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveUser(int id)
        {
            var user = _managmentCompanyDbContext.Users.First(x => x.Id == id);

            _managmentCompanyDbContext.Users.Remove(user);

            _managmentCompanyDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateUser(int id, string nickName)
        {
            var user = _managmentCompanyDbContext.Users.First(x => x.Id == id);
            user.NickName = nickName;

            _managmentCompanyDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Logon(int id, string password)
        {
            var user = _managmentCompanyDbContext.Users.FirstOrDefault(x => x.Id == id && x.Password == password);

            if (user != null)
            {
                return RedirectToAction("Profile");
            }
            else return RedirectToAction("LogError");
        }
    }
}

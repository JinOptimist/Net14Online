using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.ManagmentCompany;


namespace Net14Web.Controllers
{
    public class ManagmentCompanyController : Controller
    {
        public static List<UserViewModel> userViewModels { get; set; } = new List<UserViewModel>();

        public IActionResult Index()
        {
            return View(userViewModels);
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
            var newUser = new UserViewModel
            {
                Name = userViewModel.Name,
                NickName = userViewModel.NickName,
                Password = userViewModel.Password,
                PermissionLevel = "Пользователь",
            };
            userViewModels.Add(newUser);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveUser(string name)
        {
            var user = userViewModels.First(x => x.Name == name);
            userViewModels.Remove(user);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateUser(string name, string nickName)
        {
            userViewModels.First(x => x.Name == name).NickName = nickName;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Logon(string name, string password)
        {
            var user = userViewModels.FirstOrDefault(x => x.Name == name && x.Password == password);

            if (user != null)
            {
                return RedirectToAction("Profile");
            }
            else return RedirectToAction("LogError");
        }
    }
}

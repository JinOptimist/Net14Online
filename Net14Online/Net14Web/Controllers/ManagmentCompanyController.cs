using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.ManagmentCompany;

namespace Net14Web.Controllers
{
    public class ManagmentCompanyController : Controller
    {
        public static List<UserViewModel> userViewModels = new List<UserViewModel>();

        public IActionResult Index()
        {
            return View(userViewModels);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registrstion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrstion(AddUserViewModel userViewModel)
        {
            var newUser = new UserViewModel
            {
                Name = userViewModel.Name,
                PermissionLevel = "Пользователь",
            };

            userViewModels.Add(newUser);

            return RedirectToAction("Index");
        }
    }
}

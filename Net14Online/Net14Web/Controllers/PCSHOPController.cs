using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.PcShop;

namespace Net14Web.Controllers
{
    public class PcShopController : Controller
    {
        public static List<AddUserViewModel> UsersViewModels = new List<AddUserViewModel>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            var users = new List<UserViewModel>();

            users = UsersViewModels.ConvertAll(
            new Converter<AddUserViewModel, UserViewModel>(UsersViewModelsToUserViewModel));

            return View(users);
        }
        private UserViewModel UsersViewModelsToUserViewModel(AddUserViewModel pf)
        {
            var viewmodel = new UserViewModel();
            viewmodel.Login = pf.Login;
            viewmodel.Name = pf.Name;
            return viewmodel;
        }
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(AddUserViewModel UserModel)
        {
            UsersViewModels.Add(UserModel);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult EditUserPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditUserPassword(string login, string password)
        {
            UsersViewModels.First(x => x.Login == login).Password = password;
            return RedirectToAction(nameof(Index));
        }

        // GET: PCSHOPController/Delete/5
        public ActionResult DeleteUsers()
        {
            return View();
        }

        // POST: PCSHOPController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUsers(string login)
        {
            UsersViewModels.RemoveAll(user => user.Login == login);
            return RedirectToAction(nameof(Users));
            
        }
    }
}
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

        // GET: PCSHOPController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PCSHOPController/Edit/5
        [HttpPost]
        public ActionResult Edit(AddUserViewModel addmodel)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PCSHOPController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PCSHOPController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net14Web.DbStuff.Models.PcShop;
using Net14Web.DbStuff.Repositories.PcShop;
using Net14Web.Models.PcShop;
using Net14Web.Services;

namespace Net14Web.Controllers
{
    public class PcShopController : Controller
    {
        private UserRepositoryPcShop _userRepositoryPcShop;
        private PcsRepositoryPcShop _pcsRepositoryPcShop;
        private AuthService _authService;

        public PcShopController(UserRepositoryPcShop userRepositoryPcShop, PcsRepositoryPcShop pcsRepositoryPcShop)
        {
            _userRepositoryPcShop = userRepositoryPcShop;
            _pcsRepositoryPcShop = pcsRepositoryPcShop;
        }

        public ActionResult Index()
        {
            var userName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "name")?.Value ?? "Гость";
            return View((object)userName);
        }

        public ActionResult Users()
        {
            var dbUserPcShop = _userRepositoryPcShop.GetUsers(10);

            var viewModels = dbUserPcShop
                .Select(dbUserPcShop => new UserViewModel
                {
                    Id = dbUserPcShop.Id,
                    Name = dbUserPcShop.Name,
                    Login = dbUserPcShop.Login,
                })
                .ToList();

            return View(viewModels);
        }
        public ActionResult PCs()
        {
            var dbPCModel = _pcsRepositoryPcShop.GetPCs(10);
            return View(dbPCModel);
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(AddUserViewModel UserViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(UserViewModel);
            }
            var user = new UsersPcShop
            {
                Name = UserViewModel.Name,
                Login = UserViewModel.Login,
                Email = UserViewModel.Email,
                Password = UserViewModel.Password,
            };
            _userRepositoryPcShop.Registration(user);
            return RedirectToAction(nameof(Index));

        }
        public ActionResult EditUserPassword()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditUserPassword(int id, string password)
        {
            _userRepositoryPcShop.EditUserPassword(id, password);
            return RedirectToAction(nameof(Index));
        }

        // GET: PCSHOPController/Delete/5
        public ActionResult DeleteUsers()
        {
            return View();
        }

        // POST: PCSHOPController/Delete/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUsers(int id)
        {
            _userRepositoryPcShop.DeleteUsers(id);
            return RedirectToAction(nameof(Users));
        }
    }
}
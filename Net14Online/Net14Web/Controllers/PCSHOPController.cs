using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net14Web.DbStuff;
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
        public static List<AddUserViewModel> UsersViewModels = new List<AddUserViewModel>();
        private WebDbContext _webDbContext;
        private AuthService _authService;

        public PcShopController(UserRepositoryPcShop userRepositoryPcShop, PcsRepositoryPcShop pcsRepositoryPcShop)
        public PcShopController(WebDbContext webDbContext, AuthService authService)
        {
            _userRepositoryPcShop = userRepositoryPcShop;
            _pcsRepositoryPcShop = pcsRepositoryPcShop;
            _webDbContext = webDbContext;
            _authService = authService;
        }

        public ActionResult Index()
        {
            var userName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "name")?.Value ?? "Гость";
            return View((object)userName);
        }

        public ActionResult Users()
        {
            var dbUserPcShop = _userRepositoryPcShop.GetUsers(10);
            var dbUserPcShop = _webDbContext.UserPcShop.Take(10).ToList();
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
            var dbPCModel = _webDbContext.PCModel.Include(x => x.CPU).Take(10).ToList();
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
        public ActionResult EditUserPassword(int id, string password)
        [Authorize]
        public ActionResult EditUserPassword(int Id, string password)
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
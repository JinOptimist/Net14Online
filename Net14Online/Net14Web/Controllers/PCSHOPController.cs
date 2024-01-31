using Microsoft.AspNetCore.Mvc;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models;
using Net14Web.Models.PcShop;

namespace Net14Web.Controllers
{
    public class PcShopController : Controller
    {
        public static List<AddUserViewModel> UsersViewModels = new List<AddUserViewModel>();
        private WebDbContext _webDbContext;

        public PcShopController(WebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
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
            _webDbContext.UserPcShop.Add(user);
            _webDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public ActionResult EditUserPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditUserPassword(int Id, string password)
        {
            var user = _webDbContext.UserPcShop.First(x => x.Id == Id);
            user.Password = password;
            _webDbContext.SaveChanges();
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
        public ActionResult DeleteUsers(int id)
        {
            var user = _webDbContext.UserPcShop.First(x => x.Id == id);
            _webDbContext.UserPcShop.Remove(user);
            _webDbContext.SaveChanges();
            return RedirectToAction(nameof(Users));
            
        }
    }
}
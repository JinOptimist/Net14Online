using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models.RetroConsoles;
using Net14Web.Models.RetroConsoles;
using System.ComponentModel.DataAnnotations;

namespace Net14Web.Controllers
{
    public class RetroController : Controller
    {
        private WebDbContext _webDbContext;
        public static List<UserConsole> UsersConsoles = new List<UserConsole>();
        public RetroController(WebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Remove(int id)
        {
            var user = _webDbContext.RetroUsers.FirstOrDefault(x => x.Id == id);
            
            if (user != null)
            {
                _webDbContext.RetroUsers.Remove(user);
                _webDbContext.SaveChanges();
            }
            return RedirectToAction("UserConsoles");
        }
        [HttpPost]
        [HttpPost]
        public IActionResult UpdateEmail(int id, string email)
        {
            var user = _webDbContext.RetroUsers.FirstOrDefault(x => x.Id == id);

            if (user != null)
            {
                user.Email = email;
                _webDbContext.SaveChanges();
            }

            return RedirectToAction("UserConsoles");
        }


        public IActionResult UserConsoles()
        {
            var dbRetroUsers = _webDbContext.RetroUsers.Take(10).ToList();
            var viewRetroModels = dbRetroUsers
                .Select(dbRetroUser => new UserConsole
                {
                    Id = dbRetroUser.Id,
                    Name = dbRetroUser.Login,
                    Email = dbRetroUser.Email,
                    Password = dbRetroUser.Password,
                })
                .ToList();
            return View(viewRetroModels);
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddUser(AddUser UserConsole)
        {
            var retroUser = new RetroUser
            {
                Login = UserConsole.Name,
                Email = UserConsole.Email,
                Password = UserConsole.Password,
            };
            _webDbContext.RetroUsers.Add(retroUser);
            _webDbContext.SaveChanges();

            return RedirectToAction("UserConsoles");
        }
    }
}

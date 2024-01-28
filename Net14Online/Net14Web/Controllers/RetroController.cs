using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models.RetroConsoles;
using Net14Web.Models.RetroConsoles;
using System.Linq;

namespace Net14Web.Controllers
{
    public class RetroController : Controller
    {
        private readonly WebDbContext _webDbContext;

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
            var dbRetroUsers = _webDbContext.RetroUsers
                .Include(user => user.ConsolesRetroUsers)
                .ThenInclude(link => link.Consoles)
                .Take(10)
                .ToList();

            var viewRetroModels = dbRetroUsers
                .Select(dbRetroUser => new UserConsole
                {
                    Id = dbRetroUser.Id,
                    Name = dbRetroUser.Login,
                    Email = dbRetroUser.Email,
                    Password = dbRetroUser.Password,
                    Consoles = dbRetroUser.ConsolesRetroUsers
                        .Select(link => new ConsoleInfo
                        {
                            ConsoleName = link.Consoles.ConsoleName,
                            Year = link.Consoles.Year
                        })
                        .ToList()
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
        public IActionResult AddUser(AddUser addUser)
        {
            if (ModelState.IsValid)
            {
                var retroUser = new RetroUser
                {
                    Login = addUser.Name,
                    Email = addUser.Email,
                    Password = addUser.Password,
                };

                var console = new Consoles
                {
                    ConsoleName = addUser.ConsoleName,
                    Year = addUser.Year,
                };

                var consolesRetroUser = new ConsolesRetroUser
                {
                    RetroUser = retroUser,
                    Consoles = console
                };

                _webDbContext.RetroUsers.Add(retroUser);
                _webDbContext.Consoles.Add(console);
                _webDbContext.SaveChanges();

                _webDbContext.ConsolesRetroUsers.Add(consolesRetroUser);
                _webDbContext.SaveChanges();

                return RedirectToAction("UserConsoles");
            }

            // Если модель не прошла валидацию, возвращаем пользователя на страницу AddUser с ошибками
            return View(addUser);
        }
    }
}

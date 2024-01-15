using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.Dnd;
using Net14Web.Models.RetroConsoles;

namespace Net14Web.Controllers
{
    public class RetroController : Controller
    {
        public static List<UserConsole> UsersConsoles = new List<UserConsole>();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Remove(string name)
        {
            var user = UsersConsoles.FirstOrDefault(x => x.Name == name);

            if (user != null)
            {
                UsersConsoles.Remove(user);
            }

            return RedirectToAction("UserConsoles");
        }
        [HttpPost]
        public IActionResult UpdatePic(string name, string picurl)
        {
            var user = UsersConsoles.FirstOrDefault(x => x.Name == name);

            if (user != null)
            {
                user.PicUrl = picurl;
            }

            return RedirectToAction("UserConsoles");
        }

        public IActionResult UserConsoles()
        {
            return View(UsersConsoles);
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
       

        [HttpPost]
        public IActionResult AddUser(AddUser UserConsole)
        {
            var newUser = new UserConsole
            {
                PicUrl = UserConsole.PicUrl,
                Name = UserConsole.Name,
                NumOfConsoles = UserConsole.NumOfConsoles,
                Discription = UserConsole.Discription,
                Email = UserConsole.Email,
            };

            UsersConsoles.Add(newUser);

            return RedirectToAction("UserConsoles");
        }
    }
}

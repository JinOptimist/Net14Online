using Microsoft.AspNetCore.Mvc;

namespace Net14Web.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

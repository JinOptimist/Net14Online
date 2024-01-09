using Microsoft.AspNetCore.Mvc;
using Net14Web.Models;
using System.Diagnostics;

namespace Net14Web.Controllers
{
    public class RetroController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
   
    }
}
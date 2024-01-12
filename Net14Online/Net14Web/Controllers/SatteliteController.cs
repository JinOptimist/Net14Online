using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.Dnd;
using Net14Web.Models.Sattelite;
using System.Xml.Linq;

namespace Net14Web.Controllers
{
    public class SatteliteController : Controller
    {
        /// <summary>
        /// TEMP SOLUTION. DONT DO THIS IN PRODUCT
        /// </summary>
        public static List<Objects> ObjectModel = new List<Objects>();

        public IActionResult Index()
        {
            return View(ObjectModel);
        }

        [HttpGet]
        public IActionResult AddObject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddObject(AddObjectModel objectModel) 
        {
            var newObject = new Objects
            {
                Type = objectModel.Type,
                Name = objectModel.Name,
                IconURL = objectModel.IconURL
            };
            ObjectModel.Add(newObject);

            return RedirectToAction("Index");
        }
    }
}

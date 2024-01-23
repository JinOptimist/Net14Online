using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.Sattelite;
using Net14Web.Services;
using Net14Web.Services.Sattelite;
using System.Xml.Linq;

namespace Net14Web.Controllers
{
    public class SatteliteController : Controller
    {
        private readonly ObjectBuilder _objectBuilder;

        /// <summary>
        /// TEMP SOLUTION. DONT DO THIS IN PRODUCT
        /// </summary>
        public static List<Objects> ObjectModel = new List<Objects>();

        public SatteliteController(ObjectBuilder builder)
        {
            _objectBuilder = builder;
        }
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

        public IActionResult AddRandomObject ()
        {
            var objects = _objectBuilder.BuildRandomObject();
            ObjectModel.Add(objects);
            return RedirectToAction("Index");
        }
           
        public IActionResult RemoveObject(string name)
        {
            var objects = ObjectModel.First(x => x.Name == name);
            ObjectModel.Remove(objects);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateType(string name, string type)
        {
            ObjectModel.First(x => x.Name == name).Type = type;
            return RedirectToAction("Index");
        }
    }
}

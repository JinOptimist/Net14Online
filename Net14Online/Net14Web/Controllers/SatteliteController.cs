using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.Sattelite;
using Net14Web.Services;
using Net14Web.Services.Sattelite;
using System.Xml.Linq;
using Net14Web.DbStuff.Models.Sattelite;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models.RetroConsoles;
using Net14Web.Models.RetroConsoles;
using Net14Web.Models.InvestPortfolio;

namespace Net14Web.Controllers
{
    public class SatteliteController : Controller
    {
        private readonly ObjectBuilder _objectBuilder;

        private WebDbContext _webDbContext;
        public SatteliteController(ObjectBuilder builder, WebDbContext webDbContext)
        {

            _objectBuilder = builder;
            _webDbContext = webDbContext;
        }
        public IActionResult Index()
        {
            var dbObjects = _webDbContext.Sattelite.Take(10).ToList();
            var ObjectDict = dbObjects.Select(dbObject => new Objects
            {
                Name = dbObject.Name,
                Type = dbObject.Type,
                IconURL = dbObject.IconURL,
                Id = dbObject.Id
            }).ToList();

            return View(ObjectDict);
        }

        [HttpGet]
        public IActionResult AddObject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddObject(AddObjectModel objectModel) 
        {
            var objects = new ObjectDict
            {
                Name = objectModel.Name,
                Type = objectModel.Type,
                IconURL = objectModel.IconURL,
            };
            _webDbContext.Sattelite.Add(objects);
            _webDbContext.SaveChanges();

            return RedirectToAction("index");
        }
           
        public IActionResult RemoveObject(int id)
        {
            var objects = _webDbContext.Sattelite.FirstOrDefault(x => x.Id == id);

            if (objects != null)
            {
                _webDbContext.Sattelite.Remove(objects);
                _webDbContext.SaveChanges();
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult UpdateType(int id, string type)
        {
            var objects = _webDbContext.Sattelite.FirstOrDefault(x =>x.Id == id);
            if (objects != null)
            {
                objects.Type = type;    
                _webDbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

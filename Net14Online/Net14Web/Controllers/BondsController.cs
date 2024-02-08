using Microsoft.AspNetCore.Mvc;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models.Bonds;
using Net14Web.Models.Bonds;

namespace Net14Web.Controllers
{
    public class BondsController : Controller
    {
        private WebDbContext _webDbContext;

        public BondsController(WebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }
        public IActionResult Index()
        {
            var bdBonds = _webDbContext.Bonds.Take(10).ToList();
            var viewModel = bdBonds
                .Select(x => new BondsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price
                }).ToList();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddBonds()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBonds(AddBondsViewModel addBondsViewModel)
        {
            var bond = new Bond
            {
                Name = addBondsViewModel.Name,
                Price = addBondsViewModel.Price,
                Id = addBondsViewModel.Id
            };
            _webDbContext.Bonds.Add(bond);
            _webDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var bond = _webDbContext.Bonds.First(x => x.Id == id);
            _webDbContext.Bonds.Remove(bond);
            _webDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdatePrice(int id, int price)
        {
            var bond = _webDbContext.Bonds.First(x => x.Id == id);
            bond.Price = price;
            _webDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}


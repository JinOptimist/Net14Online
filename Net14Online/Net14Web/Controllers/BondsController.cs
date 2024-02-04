using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.Bonds;

namespace Net14Web.Controllers
{
    public class BondsController : Controller
    {
        public static List<BondsViewModel> bondsViewModels = new List<BondsViewModel>();
        public IActionResult Index()
        {
            return View(bondsViewModels);
        }

        [HttpGet]
        public IActionResult AddBonds()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBonds(AddBondsViewModel addBondsViewModel)
        {
            bondsViewModels.Add(new BondsViewModel
            {
                Name = addBondsViewModel.Name,
                Price = addBondsViewModel.Price
            });
            return RedirectToAction("Index");
        }

        public IActionResult Remove(string name)
        {
            var bond = bondsViewModels.First(x => name == x.Name);
            bondsViewModels.Remove(bond);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdatePrice(string name, int price)
        {
            var bond = bondsViewModels.First(x => name == x.Name).Price = price;
            return RedirectToAction("Index");
        }
    }
}


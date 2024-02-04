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


    }
}


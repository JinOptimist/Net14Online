using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.Dnd;
using Net14Web.Models.InvestPortfolio;

namespace Net14Web.Controllers
{
    public class InvestPortfolioController : Controller
    {
        public static List<StockViewModel> stockViewModels = new List<StockViewModel>();
        public IActionResult Index()
        {
            return View(stockViewModels);
        }

        [HttpGet]
        public IActionResult AddStock()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStock(AddStockViewModel StockViewModel)
        {
            var newStock = new StockViewModel
            {
                NameStock = StockViewModel.NameStock,
                Price = StockViewModel.Price               
            };

            stockViewModels.Add(newStock);

            return RedirectToAction("Index");
        }
        public IActionResult Remove(string name)
        {
            var stockDelete = stockViewModels.First(x => x.NameStock == name);
            stockViewModels.Remove(stockDelete);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UpdatePrice(string name, int price)
        {
            stockViewModels.First(x => x.NameStock == name).Price = price;
            return RedirectToAction("Index");
        }
    }
}


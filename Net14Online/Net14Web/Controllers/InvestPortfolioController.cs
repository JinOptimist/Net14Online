using Microsoft.AspNetCore.Mvc;
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
    }
}


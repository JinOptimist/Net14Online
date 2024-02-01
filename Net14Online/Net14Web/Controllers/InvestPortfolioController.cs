using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models;
using Net14Web.Models.InvestPortfolio;
using Net14Web.Services;

namespace Net14Web.Controllers
{
    public class InvestPortfolioController : Controller
    {
        private WebDbContext _webDbContext;

        public InvestPortfolioController(WebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public IActionResult Index()
        {
            var dbStocks = _webDbContext.Stocks.Take(10).ToList();

            var viewModels = dbStocks.Select(dbStock => new StockViewModel
            {
                NameStock = dbStock.Name,
                Price = dbStock.Price,
                Id = dbStock.Id
            }).ToList();

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult AddStock()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStock(AddStockViewModel StockViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(StockViewModel);
            }
            var stock = new Stock
            {
                Name = StockViewModel.NameStock,
                Price = StockViewModel.Price,
            };

            _webDbContext.Stocks.Add(stock);
            _webDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            var stock = _webDbContext.Stocks.First(x => x.Id == id);
            _webDbContext.Stocks.Remove(stock);
            _webDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UpdatePrice(int id, int price)
        {
            var stock = _webDbContext.Stocks.First(x => x.Id == id);
            stock.Price = price;
            _webDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddDividend()
        {
            var viewModel = new AddDividendViewModel();
            viewModel.Stocks = _webDbContext
                .Stocks
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddDividend(AddDividendViewModel AddDividendViewModel, int stockId)
        {
            var stock = _webDbContext.Stocks.First(x => x.Id == stockId);
            var dividend = new Dividend
            {
                DateOfReplenishment = AddDividendViewModel.DateOfReplenishment,

                TheAmountOfTheDividend = AddDividendViewModel.TheAmountOfTheDividend,

                Stock = stock,
                StockId = stockId

            };

            _webDbContext.Dividend.Add(dividend);
            _webDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}


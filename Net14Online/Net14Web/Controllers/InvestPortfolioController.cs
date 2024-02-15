using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Models.InvestPort;
using Net14Web.DbStuff.Repositories;
using Net14Web.Models.InvestPortfolio;

namespace Net14Web.Controllers
{
    public class InvestPortfolioController : Controller
    {
        private StockRepository _stockRepository;
        private DividendRepository _dividendRepository;


        public InvestPortfolioController(WebDbContext webDbContext, StockRepository stockRepository,
            DividendRepository dividendRepository)
        {
            _stockRepository = stockRepository;
            _dividendRepository = dividendRepository;
        }

        public IActionResult Index()
        {
            var dbStocks = _stockRepository.GetStocks(10);

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
            _stockRepository.Add(stock);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            _stockRepository.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UpdatePrice(int id, int price)
        {
            _stockRepository.UpdatePrice(id, price);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddDividend()
        {
            var viewModel = new AddDividendViewModel();
            viewModel.Stocks = _stockRepository
                .GetAll()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddDividend(AddDividendViewModel AddDividendViewModel, int stockId)
        {
            var stock = _stockRepository.GetById(stockId);
            var dividend = new Dividend
            {
                DateOfReplenishment = AddDividendViewModel.DateOfReplenishment,

                TheAmountOfTheDividend = AddDividendViewModel.TheAmountOfTheDividend,

                Stock = stock
            };

            _dividendRepository.Add(dividend);
            return RedirectToAction("Index");
        }

    }
}


using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using RealEstateNet14Web.Models;
using RealEstateNet14Web.Models.Home;
using RealEstateNet14Web.Services.ApiServices;

namespace RealEstateNet14Web.Controllers;

public class HomeController : Controller
{
    private ExchangeRatesApi _exchangeRatesApi;
    private ExchangeRatesViewBuilder _exchangeRatesViewBuilder;

    public HomeController(ExchangeRatesViewBuilder exchangeRatesViewBuilder,
        ExchangeRatesApi exchangeRatesApi)
    {
        _exchangeRatesViewBuilder = exchangeRatesViewBuilder;
        _exchangeRatesApi = exchangeRatesApi;
    }

    public async Task<IActionResult> Index()
    {
        var viewModel = new HomeIndexViewModel();
        var exchangeRates =  _exchangeRatesApi.GetExchangeRates("431");

        Task.WaitAll(exchangeRates);
        viewModel.ExchangeRatesViewModel = _exchangeRatesViewBuilder.Build(exchangeRates.Result);
        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
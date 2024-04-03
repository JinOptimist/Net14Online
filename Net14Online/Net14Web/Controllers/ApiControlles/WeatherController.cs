using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.Home;
using Net14Web.Services.ApiServices;

namespace Net14Web.Controllers.ApiControlles
{
    [ApiController]
    [Route("/api/weather/{action}")]
    public class WeatherController : Controller
    {
        private WeatherApi _weatherApi;
        private WeaterViewModelBuilder _weaterViewModelBuilder;

        public WeatherController(WeatherApi weatherApi, WeaterViewModelBuilder weaterViewModelBuilder)
        {
            _weatherApi = weatherApi;
            _weaterViewModelBuilder = weaterViewModelBuilder;
        }

        public async Task<WeatherViewModel> TodayWeather(string latitude, string longitude)
        {
            var dto = await _weatherApi.GetWeatherByCoordinate(latitude, longitude);
            var viewModel = _weaterViewModelBuilder.Build(dto);
            return viewModel;
        }
    }
}

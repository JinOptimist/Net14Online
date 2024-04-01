using Net14Web.Models.Home;

namespace Net14Web.Services.ApiServices
{
    public class WeaterViewModelBuilder
    {
        public WeatherViewModel Build(WeatherDto dto)
        {
            var viewModel = new WeatherViewModel();
            viewModel.TemperatureNow = dto.current.temperature_2m;
            viewModel.TemperaturesFor24Hours = dto.hourly.temperature_2m;
            return viewModel;
        }
    }
}
